﻿using API.Model;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        int CreateWithValidate(Employee employee);
    }
}
