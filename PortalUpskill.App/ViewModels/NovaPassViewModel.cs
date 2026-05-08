using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.ViewModels
{
    public class NovaPassViewModel
    {
        [Required, DataType(DataType.Password)]
        public string PasswordActual { get; set; }
        [Required, DataType(DataType.Password)]
        public string NovaPassword { get; set; }
        [Required, DataType(DataType.Password), Compare("NovaPassword", ErrorMessage = "Password tem de ser idêntica à anterior!")]
        public string Confirmacao { get; set; }

    }
}
