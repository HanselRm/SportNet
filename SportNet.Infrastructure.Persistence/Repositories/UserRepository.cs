using Microsoft.EntityFrameworkCore;
using SportNet.Core.Application.Helpers;
using SportNet.Core.Application.Interfaces.Repositories;
using SportNet.Core.Application.ViewModels.Users;
using SportNet.Core.Domain.Entities;
using SportNet.Infrastructure.Persistence.Context;


namespace SportNet.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly DbContex dbContext;

        public UserRepository(DbContex dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task UdapteAsync(Users entity, int id)
        {
            /*entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);*/
            await base.UdapteAsync(entity, entity.Id);
        }

        public async Task UdapteAsyncWithoutPassword(Users entity, int id)
        {
            await base.UdapteAsync(entity, entity.Id);
        }

        public override async Task<Users> AddAsync(Users entity)
        {
            entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);
            return await base.AddAsync(entity);
        }

        public async Task<Users> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypy = PasswordEncryption.ComputeSha256Hash(loginVm.Password);
            Users user = await dbContext.Set<Users>()
                .FirstOrDefaultAsync(user => user.Password == passwordEncrypy && user.UserName == loginVm.UserName);
            return user;
        }
    }
}
