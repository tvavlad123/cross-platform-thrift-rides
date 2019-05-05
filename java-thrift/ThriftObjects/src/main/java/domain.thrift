namespace java Domain

struct Employee
{
   1:i32 employeeID
   2:string firstName
   3:string lastName
   4:string username
   5:string password
   6:string office
}

struct Person
{
   1:i32 personID
   2:string firstName
   3:string lastName
}

struct EndPoint
{
	1:string hostname
	2:i32 port
}

struct Ride
{
	1:i32 rideID
	2:string destination
	3:string date
	4:string hour
	5:i32 nrSeats
}

struct Booking
{
	1:i32 bookingID
	2:i32 personID
	3:i32 rideID
	4:i32 seatNo
}