package repository;


import java.util.List;

public interface IRepository<ID, T> {

    int size();

    void save(T entity);

    void update(ID id, T entity);

    void delete(ID id);

    T findOne(ID id);

    List<T> findAll();
}
