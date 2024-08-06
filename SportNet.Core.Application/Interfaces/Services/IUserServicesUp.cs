

using SportNet.Core.Application.ViewModels.Users;
using SportNet.Core.Domain.Entities;

namespace SportNet.Core.Application.Interfaces.Services
{
    public interface IUserServicesUp<EditViewModel> : IGenericServices<SaveUserViewModel, UserViewModel, Users>
    {
        Task<SaveUserViewModel> Login(LoginViewModel vm);
        Task<Boolean> GetByUserNameViewModel(string userName);
        Task Update(EditViewModel vm, int id);
        Task<EditUserViewModel> GetByIdEditViewModel(int id);

    }
}
