

using SportNet.Core.Application.Interfaces.Repositories;
using SportNet.Core.Domain.Entities;
using SportNet.Infrastructure.Persistence.Context;

namespace SportNet.Infrastructure.Persistence.Repositories
{
    public class EventRepository : GenericRepository<Events>, IEventRepository
    {
        private readonly DbContex dbContext;

        public EventRepository(DbContex dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
