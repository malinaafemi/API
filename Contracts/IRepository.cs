using API.Model;

namespace API.Contracts
{
    public interface IRepository<T>
    {
        T Create(T item);
        bool Update(T item);
        bool Delete(Guid guid);
        IEnumerable<T> GetAll();
        T? GetByGuid(Guid guid);

    }
}
