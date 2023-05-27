using PiaTienda.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PiaTienda.Entidades
{
    public class Ventas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EsNumerico]
        public int Total { get; set; }
        public Clientes Clientes { get; set; }

      
    }
}
