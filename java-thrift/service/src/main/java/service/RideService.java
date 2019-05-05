package service;

import Domain.Ride;
import repository.IRepository;

import java.util.Comparator;
import java.util.List;

public class RideService extends AbstractService<Integer, Ride> {
    public RideService(IRepository<Integer, Ride> repository) {
        super(repository);
    }

    public List<Ride> filterDestinationDateHour(String destination, String date, String hour) {
        return filterAndSorter(this.getAll(),
                x -> x.getDestination().toLowerCase().contains(destination.toLowerCase()) && x.getDate().contains(date)
                        && x.getHour().contains(hour), Comparator.comparing(Ride::getRideID)
        );
    }
}
