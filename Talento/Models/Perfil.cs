using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Talento.Models
{
    public class Perfil
    {

        public string Membresia { get; set; }
        
        [Required(ErrorMessage = "Debes Ingresar tu Apellido Paterno")]
        [StringLength(50)]
        [Display(Name = "Apellido Paterno")]
        public string Apaterno { get; set; }


        [Required(ErrorMessage = "Debes Ingresar tu Apellido Materno")]
        [StringLength(50)]
        [Display(Name = "Apellido Materno")]
        public string Amaterno { get; set; }


        
        [StringLength(50)]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }

        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña:")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [StringLength(255)]
        public string Empresa { get; set; }

        [StringLength(255)]
        public string GiroEmpresa { get; set; }
     
        [StringLength(250)]
        public string Puesto { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefono no válido")]
        public string Telefono { get; set; }


        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo no válido")]
        public string Correo { get; set; }
 
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [StringLength(10)]
        public string TipoMembresia { get; set; }
   

    }
}
