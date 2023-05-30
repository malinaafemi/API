using API.Model;
using Microsoft.EntityFrameworkCore;
using API.Utility;
namespace API.Contexts

{
    public class BookingManagementDbContext : DbContext
    {
        public BookingManagementDbContext(DbContextOptions<BookingManagementDbContext> options) : base(options)
        {


        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>().HasData(new Role
            {
                Guid = Guid.Parse("2483B7C6-10BD-4EE4-69D9-08DB60BF2967"),
                Name = nameof(RoleLevel.User),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            },
            new Role
            {
                Guid = Guid.Parse("6AAAD8E7-364F-45D9-69DA-08DB60BF2967"),
                Name = nameof(RoleLevel.Manager),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Role
            {
                Guid = Guid.Parse("17886CC3-5AD9-4640-69DB-08DB60BF2967"),
                Name = nameof(RoleLevel.Admin),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            });

            builder.Entity<Employee>().HasIndex(e => new
            {
                e.NIK,
                e.Email,
                e.PhoneNumber
            }).IsUnique();

            // Relation between Education and University (1 to Many)

            builder.Entity<Education>().HasOne(u => u.University).WithMany(e => e.Educations).HasForeignKey(e => e.UniversityGuid);

            //.OnDelete()

            builder.Entity<Education>().HasOne(e => e.Employee).WithOne(e => e.Education).HasForeignKey<Education>(e => e.Guid);

            builder.Entity<Account>().HasOne(e => e.Employee).WithOne(a => a.Account).HasForeignKey<Account>(a => a.Guid);

            builder.Entity<Booking>().HasOne(e => e.Employee).WithMany(b => b.Bookings).HasForeignKey(b => b.EmployeeGuid);

            builder.Entity<Booking>().HasOne(r => r.Room).WithMany(b => b.Bookings).HasForeignKey(b => b.RoomGuid);

            builder.Entity<AccountRole>().HasOne(a => a.Account).WithMany(a => a.AccountRoles).HasForeignKey(a => a.AccountGuid);

            builder.Entity<AccountRole>().HasOne(r => r.Role).WithMany(a => a.AccountRoles).HasForeignKey(a => a.RoleGuid);

        }





        }
}
