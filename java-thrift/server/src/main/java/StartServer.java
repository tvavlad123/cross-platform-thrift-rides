import Service.ITransportServer;
import org.apache.thrift.TMultiplexedProcessor;
import org.apache.thrift.server.TThreadPoolServer;
import org.apache.thrift.transport.TServerSocket;
import repository.*;


public class StartServer {

    public static void main(String[] args) {
        DBUtils dbUtils = new DBUtils("db.properties");
        EmployeeJDBCRepository userDBRepository = new EmployeeJDBCRepository(dbUtils);
        RideJDBCRepository tripDBRepository = new RideJDBCRepository(dbUtils);
        BookingJDBCRepository reservationDBRepository = new BookingJDBCRepository(dbUtils);
        PersonJDBCRepository personJDBCRepository = new PersonJDBCRepository(dbUtils);
        TransportServer turismServer = new TransportServer(userDBRepository, tripDBRepository, reservationDBRepository, personJDBCRepository);
        ITransportServer.Processor<ITransportServer.Iface> turismProcessor = new ITransportServer.Processor<>(turismServer);

        TMultiplexedProcessor processor = new TMultiplexedProcessor();

        processor.registerProcessor("Iface", turismProcessor);

        try {
            TServerSocket transport = new TServerSocket(8081);
            TThreadPoolServer.Args args1 = new TThreadPoolServer.Args(transport);
            args1.processor(processor);
            TThreadPoolServer server = new TThreadPoolServer(args1);
            server.serve();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
