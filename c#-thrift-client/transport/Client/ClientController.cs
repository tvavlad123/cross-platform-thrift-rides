using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientController : ITransportObserver.Iface
    {
        public event EventHandler<EmployeeEventArgs> UpdateEvent;
        private readonly ITransportServer.Iface _server;
        private Employee _currentEmployee;

        public ClientController(ITransportServer.Iface server)
        {
            _server = server;
            _currentEmployee = null;
        }

        public bool Login(string username, string password, int port)
        {
            var employee = new Employee { Username = username, Password = password };
            var result = _server.login(employee, new EndPoint()
            {
                Hostname = "localhost",
                Port = port
            });

            if (!result) return false;
            Console.WriteLine(@"Login succeeded ....");
            _currentEmployee = employee;
            Console.WriteLine(@"Current employee {0}", employee.Username);
            return true;
        }

        public List<Ride> GetAllRides()
        {
            var result = _server.getAllRides();
            Console.WriteLine(@"Get all rides succeeded ....");
            return result;
        }

        public List<Person> GetAllPersons()
        {
            var result = _server.getAllPersons();
            Console.WriteLine(@"Get all persons succeeded ....");
            return result;
        }

        public List<Booking> GetAllBookings()
        {
            var result = _server.getAllBookings();
            Console.WriteLine(@"Get all bookings succeeded ....");
            return result;
        }

        public List<Ride> GetCustomRides(string destination, string date, string hour)
        {
            var result = _server.getCustomRides(destination, date, hour);
            Console.WriteLine(@"Get custom rides succeeded ....");
            return result;
        }

        protected virtual void OnUpdateEvent(EmployeeEventArgs e)
        {
            UpdateEvent?.Invoke(this, e);
            Console.WriteLine(@"Update Event called");
        }

        public void AddBooking(Ride ride, Booking booking, Person person)
        {
            var allTrips = _server.addBooking(ride, booking, _currentEmployee, person);
            var userArgs = new EmployeeEventArgs(allTrips, EmployeeEvent.BookingAdded);
            OnUpdateEvent(userArgs);
            Console.WriteLine(@"Make reservation succeeded ....");
        }

        public void Logout()
        {
            _server.logout(_currentEmployee);
            _currentEmployee = null;
            Console.WriteLine(@"Log out succeeded ....");
        }

        public void updateRides(List<Ride> rides)
        {
            Console.WriteLine(@"Received an update ....");
            var employeeArgs = new EmployeeEventArgs(rides, EmployeeEvent.BookingAdded);
            OnUpdateEvent(employeeArgs);
        }
    }
}
