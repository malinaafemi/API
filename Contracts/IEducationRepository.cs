using API.Model;

namespace API.Contracts
{
    public interface IEducationRepository : IRepository<Education>
    {
        Education Create(Education education);
        bool Update(Education education);
        bool Delete(Guid guid);
        IEnumerable<Education> GetAll();
        Education? GetByGuid(Guid guid);
    }
}
