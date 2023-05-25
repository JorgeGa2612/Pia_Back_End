using System.ComponentModel.DataAnnotations;
using PiaTienda.Validaciones;

namespace PiaTienda.Entidades
{
    public class Articulos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} solo puede tener hasta 5 caracteres")]
        [PrimeraLetraMayuscula]
        public string NombreArticulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Precio { get; set; }

        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CategoriasId { get; set; }
        public Categorias Categorias { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Para que se ejecuten debe de primero cumplirse con las reglas por Atributo Ejemplo: Range
            // Tomar a consideración que primero se ejecutaran las validaciones mappeadas en los atributos
            // y posteriormente las declaradas en la entidad
            if (!string.IsNullOrEmpty(NombreArticulo))
            {
                var primeraLetra = NombreArticulo[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula",
                        new String[] { nameof(NombreArticulo) });
                }
            }
        }

        }
}
