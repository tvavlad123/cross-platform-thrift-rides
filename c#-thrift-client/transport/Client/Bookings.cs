using Client;
using Domain;
using System;
using System.Windows.Forms;

namespace Transport.Controller
{
    public partial class Bookings : Form
    {
        private Ride _ride;

        private readonly ClientController _clientController;

        public Bookings(Ride ride, ClientController clientController)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _ride = ride;
            _clientController = clientController;
            noPlaces.Maximum = 18;
            label1.Text = ride.Destination + Environment.NewLine + ride.Date + Environment.NewLine +
                          ride.Hour;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Person person in _clientController.GetAllPersons())
                {
                    if (person.FirstName.Equals(firstName.Text.Trim()) && person.LastName.Equals(lastName.Text.Trim())) {
                        int counter = Decimal.ToInt32(noPlaces.Value);
                        while (counter >= 1)
                        {
                            Random randomNumber = new Random();
                            bool correct = true;
                            int rInt = 0;
                            while (correct)
                            {
                                rInt = randomNumber.Next(1, 18);
                                foreach (Booking booking in _clientController.GetAllBookings())
                                {
                                    if (rInt == booking.SeatNo)
                                    {
                                        break;
                                    }
                                }
                                correct = false;
                            }
                            int id = _clientController.GetAllBookings().Count + 1;
                            _clientController.AddBooking(_ride, new Booking
                            {
                                BookingID = id,
                                RideID = _ride.RideID,
                                PersonID = person.PersonID,
                                SeatNo = rInt
                            }, person);
                            counter--;
                        }
                    }
                        

                }
                
                MessageBox.Show(@"Rezervare facuta cu succes !", @"Rezervare", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (Exception repositoryException)
            {
                MessageBox.Show(repositoryException.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
