using API.Contexts;
using API.Contracts;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class AccountRepository : GeneralRepository<Account>, IAccountRepository
{
    public AccountRepository(BookingManagementDbContext context) : base(context) { }
    
}
