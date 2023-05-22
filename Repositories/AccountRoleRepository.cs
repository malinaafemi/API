using API.Contexts;
using API.Contracts;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(BookingManagementDbContext context) : base(context) { }

}
