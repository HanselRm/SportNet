

using SportNet.Core.Application.ViewModels.Users;
using SportNet.Core.Domain.Entities;

namespace SportNet.Core.Application.Interfaces.Services
{
    public interface IUserServices : IGenericServices<SaveUserViewModel, UserViewModel, Users>, IUserServicesUp<EditUserViewModel>


    {

    }
}
