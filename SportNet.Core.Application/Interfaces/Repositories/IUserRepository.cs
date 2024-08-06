

using SportNet.Core.Application.ViewModels.Users;
using SportNet.Core.Domain.Entities;

namespace SportNet.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Task<Users> LoginAsync(LoginViewModel loginVm);
    }
}
