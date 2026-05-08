using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Introduza primeiro o seu email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduza a sua password."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
