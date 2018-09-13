using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Talento.Models
{
    public class CandidatoViewModel
    {
        [Key]
        public int IdCandidato { get; set; }

        [Required(ErrorMessage = "Debes Ingresar tu Apellido Paterno")]
        [StringLength(50)]
        public string Apaterno { get; set; }

        [Required(ErrorMessage = "Debes Ingresar tu Apellido Materno")]
        [StringLength(50)]
        public string Amaterno { get; set; }

        [Required(ErrorMessage = "Debes Ingresar tu nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(2)]
        public int Edad { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "")]
        public DateTime FechaDeNacimineto { get; set; }

        [Required]
        [StringLength(50)]
        public string Pais { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }

        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }

        [Required]
        [DataType(DataType.PostalCode, ErrorMessage = "Ingresa un código postal válido")]
        public int CodigoPostal { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo no válido")]
        public string Correo { get; set; }


        [StringLength(10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefono no válido")]
        public int Telefono { get; set; }

        
        [StringLength(10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefono no válido")]
        public int Celular { get; set; }

        [StringLength(100)]
        public string Escolaridad { get; set; }

        [StringLength(100)]
        public string UltimoPuesto { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int SueldoDeseado { get; set; }

        [StringLength(255)]
        public string Comentarios { get; set; }

        [Required]
        public bool AvisoPrivacidad { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
