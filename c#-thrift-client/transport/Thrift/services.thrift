namespace csharp Service

include "domain.thrift"

service ITransportObserver
{
	oneway void updateRides(1:list<domain.Ride> rides)
}

service ITransportServer
{
	bool login(1:domain.Employee employee, 2:domain.EndPoint endpoint)
	list<domain.Ride> getAllRides()
	list<domain.Ride> getCustomRides(1:string destination, 2:string date, 3:string hour)
	list<domain.Person> getAllPersons()
	list<domain.Ride> addBooking(1:domain.Ride ride, 2:domain.Booking booking, 3:domain.Employee employee, 4:domain.Person person)
	void logout(1:domain.Employee employee)
	list<domain.Booking> getAllBookings()
}