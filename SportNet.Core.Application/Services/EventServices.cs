

using AutoMapper;
using SportNet.Core.Application.Interfaces.Repositories;
using SportNet.Core.Application.Interfaces.Services;
using SportNet.Core.Application.ViewModels.Event;
using SportNet.Core.Domain.Entities;

namespace SportNet.Core.Application.Services
{
    public class EventServices : GenericServices<SaveEventViewModel, EventViewModel, Events>, IEventServices
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventServices(IEventRepository eventRepository, IMapper mapper) : base(eventRepository, mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
    }
}
