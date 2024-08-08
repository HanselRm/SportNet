using AutoMapper;
using SportNet.Core.Application.Interfaces.Repositories;
using SportNet.Core.Application.Interfaces.Services;


namespace SportNet.Core.Application.Services
{
    public class GenericServices<SaveViewModel, ViewModel, Entity> : IGenericServices<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericServices(IGenericRepository<Entity> genericRepository, IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            entity = await _repository.AddAsync(entity);

            SaveViewModel model = _mapper.Map<SaveViewModel>(entity);

            return model;
        }

        public virtual async Task<List<ViewModel>> GetAllViewModels()
        {
            var EntityList = await _repository.GetAllAsync();
            return _mapper.Map<List<ViewModel>>(EntityList);

        }

        public virtual async Task Delete(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }


        public virtual async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);
            return vm;
        }


        public virtual async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            await _repository.UdapteAsync(entity, id);
        }
    }
}
