namespace PiaTienda.Entidades
{
    public class Categorias
    {
        public int Id { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public List<Articulos> Articulos { get; set; }
    }
}
