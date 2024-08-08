

namespace SportNet.Core.Application.Interfaces.Services
{
    public interface IGenericServices<SaveViewModel, ViewModel, Entity>
            where SaveViewModel : class
            where ViewModel : class
            where Entity : class
    {
        Task Update(SaveViewModel vm, int id);
        Task<SaveViewModel> Add(SaveViewModel vm);
        Task Delete(int id);
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task<List<ViewModel>> GetAllViewModels();
    }
}
