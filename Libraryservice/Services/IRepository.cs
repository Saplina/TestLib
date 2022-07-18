namespace Libraryservice.Services
{
    public interface IRepository<T>
    {
        int? Add(T item);

        int Update(T item);

        int Delete(T item);

        IList<T> GetAll();

        T GetById<TId>(TId id);
    }
}
