﻿using API.Model;

namespace API.Contracts
{
    public interface IAccountRoleRepository
    {
        AccountRole Create(AccountRole accountrole);
        bool Update(AccountRole accountrole);
        bool Delete(Guid guid);
        IEnumerable<AccountRole> GetAll();
        AccountRole? GetByGuid(Guid guid);
    }
}
