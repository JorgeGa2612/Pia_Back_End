namespace PiaTienda.Entidades
{
    public class Articulos
    {
        public int Id { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int CategoriasId { get; set; }
        public Categorias Categorias { get; set; }

    }
}
