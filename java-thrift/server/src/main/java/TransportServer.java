import Domain.Employee;
import Domain.EndPoint;
import Service.ITransportObserver;
import Service.ITransportServer;
import org.apache.thrift.protocol.TBinaryProtocol;
import org.apache.thrift.protocol.TMultiplexedProtocol;
import org.apache.thrift.transport.TSocket;
import repository.BookingJDBCRepository;
import repository.PersonJDBCRepository;
import repository.RideJDBCRepository;
import repository.EmployeeJDBCRepository;
import service.RideService;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class TransportServer implements ITransportServer.Iface {
    private EmployeeJDBCRepository employeeJDBCRepository;
    private RideJDBCRepository rideJDBCRepository;
    private BookingJDBCRepository bookingJDBCRepository;
    private PersonJDBCRepository personJDBCRepository;
    private Map<String, EndPoint> observers;

    public TransportServer(EmployeeJDBCRepository employeeJDBCRepository, RideJDBCRepository rideJDBCRepository, BookingJDBCRepository bookingJDBCRepository, PersonJDBCRepository personJDBCRepository) {
        this.employeeJDBCRepository = employeeJDBCRepository;
        this.rideJDBCRepository = rideJDBCRepository;
        this.bookingJDBCRepository = bookingJDBCRepository;
        this.personJDBCRepository = personJDBCRepository;
        observers = new HashMap<>();
    }

    @Override
    public boolean login(Domain.Employee employee, EndPoint endpoint) {
        boolean userOk = employeeJDBCRepository.login(employee.username, employee.password);
        if (!userOk) return false;
        if (observers.containsKey(employee.getUsername()))
            return false;
        observers.put(employee.getUsername(), endpoint);
        return true;
    }

    @Override
    public List<Domain.Ride> getAllRides() {
        return rideJDBCRepository.findAll();
    }

    @Override
    public List<Domain.Booking> getAllBookings() { return bookingJDBCRepository.findAll(); }

    @Override
    public List<Domain.Person> getAllPersons() { return personJDBCRepository.findAll(); }

    @Override
    public List<Domain.Ride> getCustomRides(String destination, String date, String hour) {
        RideService rideService = new RideService(rideJDBCRepository);
        return rideService.filterDestinationDateHour(destination, date, hour);
    }

    @Override
    public List<Domain.Ride> addBooking(Domain.Ride ride, Domain.Booking booking, Domain.Employee employee, Domain.Person person) {
        int seatNo = 0;
        bookingJDBCRepository.save(booking);
        for (Domain.Booking booking1 : bookingJDBCRepository.findAll()) {

            if (ride.getRideID() == booking1.getRideID()) {
                seatNo++;
            }
        }
        int seats = 18 - seatNo;
        if (seats <= 0) seats = 0;
        ride.setNrSeats(seats);
        rideJDBCRepository.update(ride.getRideID(), ride);
        List<Domain.Ride> allRides = rideJDBCRepository.findAll();
        ExecutorService executor = Executors.newFixedThreadPool(defaultThreadsNo);

        for (String x : observers.keySet())
            if (!x.equals(employee.getUsername()))
                executor.execute(() -> {
                    TSocket transport = new TSocket(observers.get(x).hostname, observers.get(x).port);
                    TBinaryProtocol binaryProtocol = new TBinaryProtocol(transport);

                    TMultiplexedProtocol turismObserverProtocol = new TMultiplexedProtocol(binaryProtocol, "Iface");

                    ITransportObserver.Iface server = new ITransportObserver.Client(turismObserverProtocol);
                    try {
                        transport.open();
                        server.updateRides(allRides);
                    } catch (Exception e) {
                        e.printStackTrace();
                    } finally {
                        transport.close();
                    }
                });
        executor.shutdown();

        return allRides;
    }

    @Override
    public void logout(Employee employee) {
        observers.remove(employee.getUsername());
    }

    private final int defaultThreadsNo = 5;
}
