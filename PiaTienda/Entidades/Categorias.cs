using PiaTienda.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PiaTienda.Entidades

{
    public class Categorias
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public List<Articulos> Articulos { get; set; }
    }
}
