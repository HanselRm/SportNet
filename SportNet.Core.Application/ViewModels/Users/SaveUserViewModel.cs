


using SportNet.Core.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SportNet.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo apellido es requerido")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo numero es requerido")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "El campo email es requerido")]

        public string Email { get; set; }
        [Required(ErrorMessage = "El campo nombre de usuario es requerido")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo contraseña es requerido")]

        public string Password { get; set; }

        public bool Status { get; set; }
    }
}
