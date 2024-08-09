using System.ComponentModel.DataAnnotations;


namespace SportNet.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo Nombre de Usuario es requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        public string Password { get; set; }
    }
}
