using SportNet.Core.Application.ViewModels.Users;
using SportNet.Core.Application.Helpers;

namespace SportNet.MiddledWares
{
    public class ValidateUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool hasUser()
        {
            SaveUserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<SaveUserViewModel>("User");
            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }
    }
}
