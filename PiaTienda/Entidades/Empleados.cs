using System.ComponentModel.DataAnnotations;
using PiaTienda.Validaciones;

namespace PiaTienda.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} solo puede tener hasta 5 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} solo puede tener hasta 5 caracteres")]
        [PrimeraLetraMayuscula]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string FechaIngreso { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contrasena { get; set; }

    }
}
