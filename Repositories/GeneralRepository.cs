using API.Contexts;
using API.Contracts;
using API.Model;

namespace API.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        protected readonly BookingManagementDbContext _context;
        public GeneralRepository(BookingManagementDbContext context)
        {
            _context = context;
        }

        public T Create(T item)
        {
            try
            {
                typeof(T).GetProperty("CreatedDate")!.SetValue(item, DateTime.Now);
                typeof(T).GetProperty("ModifiedDate")!.SetValue(item, DateTime.Now);

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
                var guid = (Guid)typeof(T).GetProperty("Guid")!.GetValue(item)!;

                var oldEntity = GetByGuid(guid);
                if(oldEntity == null)
                {
                    return false;
                }

                var getCreatedDate = typeof(T).GetProperty("CreatedDate")!.GetValue(oldEntity)!;

                typeof(T).GetProperty("CreatedDate")!.SetValue(item, getCreatedDate);
                typeof(T).GetProperty("ModifiedDate")!.SetValue(item, DateTime.Now);

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
            var item =  _context.Set<T>().Find(guid);
            _context.ChangeTracker.Clear();
            return item;
        }
    }
}
