using System.ComponentModel.DataAnnotations;
using PiaTienda.Validaciones;

namespace PiaTienda.Entidades
{
    public class Distribuidores
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} solo puede tener hasta 5 caracteres")]
        [PrimeraLetraMayuscula]
        public string NombreDistribuidor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
