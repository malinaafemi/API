using API.Model;

namespace API.Contracts
{
    public interface IEducationRepository : IGeneralRepository<Education>
    {
        IEnumerable<Education> GetByUniversityId(Guid universityId);

    }
}
