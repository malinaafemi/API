using API.Contexts;
using API.Contracts;
using API.Model;
using System.Xml.Linq;

namespace API.Repositories;

public class UniversityRepository : GeneralRepository<University>, IUniversityRepository
{
    public UniversityRepository(BookingManagementDbContext context) : base(context) { }
    public IEnumerable<University> GetByName(string name)
    {
        return _context.Set<University>().Where(u => u.Name.Contains(name));
    }
}