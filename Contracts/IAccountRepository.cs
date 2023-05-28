using API.Model;
using API.ViewModels.Accounts;

namespace API.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account>
    {
        int Register(RegisterVM registerVM);

        LoginVM Login(LoginVM loginVM);

        int ChangePasswordAccount(Guid? employeeId, ChangePasswordVM changePasswordVM);

        int UpdateOTP(Guid? employeeId);
    }
}
