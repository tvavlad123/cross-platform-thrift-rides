﻿using Client;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace Transport.Controller
{
    public partial class TransportWindow : Form
    {
        private readonly ClientController _clientController;

        private Task _updates;

        private List<Ride> _allRides;

        private readonly TThreadPoolServer _server;

        public TransportWindow(ClientController clientController, int port)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ridesView.ReadOnly = true;
            bookingsView.ReadOnly = true;
            bookingsView.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            _clientController = clientController;
            _clientController.UpdateEvent += _clientController_UpdateEvent;

            NotifyOnEvent();
            var clientProcessor = new ITransportObserver.Processor(_clientController);

            var processor = new TMultiplexedProcessor();

            processor.RegisterProcessor(nameof(ITransportServer.Iface), clientProcessor);

            var trasport = new TServerSocket(port);
            _server = new TThreadPoolServer(processor, trasport);
            FormClosed += (a, b) => {
                _clientController.Logout();
                _clientController.UpdateEvent -= _clientController_UpdateEvent;
                _server.Stop();
            };
            _updates = Task.Run(() =>
            {
                _server.Serve();
            });
        }

        public delegate void UpdateDataCallback(DataGridView ridesView, DataGridView bookingsView,
            List<Ride> list1, List<Ride> list2);

        private void _clientController_UpdateEvent(object sender, EmployeeEventArgs e)
        {
            if (e.EmployeeEvent == EmployeeEvent.BookingAdded)
            {
                var allRides = (List<Ride>)e.Data;
                var customRides = searchByDestination.Text.Trim().Length > 0 ? allRides
                    .Where(x => x.Destination.ToLower().Contains(searchByDestination.Text.Trim().ToLower())
                                 && x.Date.Contains(searchByDate.Text.Trim()) &&
                                                     x.Hour.Contains(searchByHour.Text.Trim())).OrderBy(x => x.RideID).ToList() : new List<Ride>();
                BeginInvoke(new UpdateDataCallback(Target), ridesView, bookingsView, allRides, customRides);
            }
        }

        public void NotifyOnEvent()
        {
            ridesView.Rows.Clear();
            bookingsView.Rows.Clear();
            searchByDestination.Clear();
            searchByDate.Clear();
            searchByHour.Clear();
            foreach (Ride ride in _clientController.GetAllRides())
            {
                int seatCounter = 0;
                foreach (Booking booking in _clientController.GetAllBookings())
                {
                    if (ride.RideID == booking.RideID)
                    {
                        seatCounter++;
                    }
                }
                int seatNo = 18 - seatCounter;
                if (seatNo <= 0) seatNo = 0;
                ridesView.Rows.Add(ride.Destination, ride.Date, ride.Hour, seatNo);
            }
        }

        private void Target(DataGridView ridesView, DataGridView bookingsView, List<Ride> list1, List<Ride> list2)
        {
            _allRides = new List<Ride>();
            ridesView.Rows.Clear();
            bookingsView.Rows.Clear();
            foreach (var ride in list1)
            {
                int seatCounter = 0;
                foreach (Booking booking in _clientController.GetAllBookings())
                {
                    if (ride.RideID == booking.RideID)
                    {
                        seatCounter++;
                    }
                }
                int seatNo = 18 - seatCounter;
                if (seatNo <= 0) seatNo = 0;
                ridesView.Rows.Add(ride.Destination, ride.Date, ride.Hour, seatNo);
            }

            foreach (var ride in list2)
            {
                List<int> seats = new List<int>();
                foreach (Booking booking in _clientController.GetAllBookings())
                {
                    if (booking.RideID == ride.RideID)
                    {
                        foreach (Person person in _clientController.GetAllPersons())
                        {
                            if (person.PersonID == booking.PersonID)
                            {
                                seats.Add(booking.SeatNo);
                                bookingsView.Rows.Add($"{person.FirstName} {person.LastName}", booking.SeatNo, "Already booked");
                            }
                        }

                    }
                }

                for (int index = 1; index <= 18; index++)
                {
                    if (seats.IndexOf(index) == -1)
                    {
                        bookingsView.Rows.Add("-", index, "Booking available");
                    }
                }
                bookingsView.Sort(bookingsView.Columns["SeatNo"], ListSortDirection.Ascending);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string destination = searchByDestination.Text.Trim();
            if (destination.Length == 0)
            {
                MessageBox.Show("Destination cannot be empty");
                return;
            }

            if (!DateTime.TryParse(searchByDate.Text, out DateTime date))
            {
                MessageBox.Show("Not a valid date.");
                return;
            }

            if (!DateTime.TryParse(searchByHour.Text, out DateTime hour))
            {
                MessageBox.Show("Not a valid hour.");
                return;
            }

            bookingsView.Rows.Clear();
            _allRides = new List<Ride>();
            Ride ride = _clientController.GetCustomRides(destination, date.ToString("yyyy-MM-dd"), hour.ToString(@"HH\:mm"))[0];
            _allRides.Add(ride);
            List<int> seats = new List<int>();
            foreach (Booking booking in _clientController.GetAllBookings())
            {
                if (booking.RideID == ride.RideID)
                {
                    foreach (Person person in _clientController.GetAllPersons())
                    {
                        if (person.PersonID == booking.PersonID)
                        {
                            seats.Add(booking.SeatNo);
                            bookingsView.Rows.Add($"{person.FirstName} {person.LastName}", booking.SeatNo, "Already booked");
                        }
                    }

                }
            }

            for (int index = 1; index <= 18; index++)
            {
                if (seats.IndexOf(index) == -1)
                {
                    bookingsView.Rows.Add("-", index, "Booking available");
                }
            }
            bookingsView.Sort(bookingsView.Columns["SeatNo"], ListSortDirection.Ascending);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _server.Stop();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!_allRides.Any())
            {
                MessageBox.Show("Please search for a ride.");
                return;
            }
            var booking = new Bookings(_allRides[0], _clientController);
            Hide();
            booking.Show();
            booking.FormClosed += (a, b) => Show();
        }
    }

}
