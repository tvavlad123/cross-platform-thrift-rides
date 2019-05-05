package service;

import repository.IRepository;

import java.util.Comparator;
import java.util.List;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class AbstractService<ID, E> implements IService<ID, E> {

    private IRepository<ID, E> repository;

    public AbstractService(IRepository<ID, E> repository) {
        this.repository = repository;
    }

    @Override
    public void add(E item) {
        repository.save(item);
    }

    @Override
    public void update(ID id, E item) {
        repository.update(id, item);
    }

    @Override
    public void remove(ID id) {
        repository.delete(id);
    }

    @Override
    public List<E> getAll() {
        return repository.findAll();
    }

    @Override
    public E find(ID id) {
        return repository.findOne(id);
    }

    @Override
    public List<E> filterAndSorter(List<E> lista, Predicate<E> filter, Comparator<E> comparator) {
        return lista
                .stream()
                .filter(filter)
                .sorted(comparator)
                .collect(Collectors.toList());
    }

    @Override
    public Integer getSize() {
        return repository.size();
    }
}
