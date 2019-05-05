package service;

import java.util.Comparator;
import java.util.List;
import java.util.function.Predicate;

public interface IService<ID, E> {
    void add(E item);

    void update(ID id, E item);

    void remove(ID id);

    List<E> getAll();

    E find(ID id);

    List<E> filterAndSorter(List<E> lista, Predicate<E> filter, Comparator<E> comparator);

    Integer getSize();
}
