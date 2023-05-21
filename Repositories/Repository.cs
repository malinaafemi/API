using API.Contexts;
using API.Contracts;
using API.Model;

namespace API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookingManagementDbContext _context;
        public Repository(BookingManagementDbContext context)
        {
            _context = context;
        }

        public T Create(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
                _context.SaveChanges();
                return item;
            }
            catch
            {
                return default(T);
            }
        }

        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid guid)
        {
            try
            {
                var item = GetByGuid(guid);
                if (item == null)
                {
                    return false;
                }

                _context.Set<T>().Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetByGuid(Guid guid)
        {
            return _context.Set<T>().Find(guid);
        }
    }
}
