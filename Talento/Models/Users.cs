using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talento.Models
{
    public partial class Users
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string Membresia { get; set; }
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
        [StringLength(255)]
        public string Empresa { get; set; }
        [Required]
        [StringLength(255)]
        public string GiroEmpresa { get; set; }
        [Required]
        [StringLength(250)]
        public string Puesto { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Telefono no válido")]
        public string Telefono { get; set; }
        
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo no válido")]
        public string Correo { get; set; }
        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }
        [Required]
        [StringLength(10)]
        public string TipoMembresia { get; set; }
        [Required]
        [DataType(DataType.Date,ErrorMessage ="")]
        public DateTime? FechaIngreso { get; set; }
        [ForeignKey("Id")]
        public string UID { get; set; }
        public Users IdUsuarioNavigation { get; set; }
        public Users InverseIdUsuarioNavigation { get; set; }
    }
}
