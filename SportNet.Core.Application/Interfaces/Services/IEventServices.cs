

using SportNet.Core.Application.ViewModels.Event;
using SportNet.Core.Domain.Entities;

namespace SportNet.Core.Application.Interfaces.Services
{
    public interface IEventServices : IGenericServices<SaveEventViewModel, EventViewModel, Events>
    {
    }
}
