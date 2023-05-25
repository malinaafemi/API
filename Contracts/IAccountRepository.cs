using API.Model;
using API.ViewModels.Accounts;

namespace API.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account>
    {
        int Register(RegisterVM registerVM);

    }
}
