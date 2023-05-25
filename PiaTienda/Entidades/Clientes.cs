using PiaTienda.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiaTienda.Entidades
{
    public class Clientes
    {
        //get ans set methods for the class clientes (id, nombre, edad, fecha)
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} solo puede tener hasta 5 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }


        [Range(18, 100, ErrorMessage = "El campo Edad no se encuentra dentro del rango")]
        [NotMapped]
        public int Edad { get; set; }
        public string Fecha { get; set; }
        public List<Ventas> Ventas { get; set; }
    
    }
}
