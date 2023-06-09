﻿using API.Model;

namespace API.Contracts
{
    public interface IUniversityRepository : IGeneralRepository<University>
    {
        University CreateWithValidate(University university);
    }
}
