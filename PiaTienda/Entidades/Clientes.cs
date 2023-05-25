namespace PiaTienda.Entidades
{
    public class Clientes
    {
        //get ans set methods for the class clientes (id, nombre, edad, fecha)
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Fecha { get; set; }
        public List<Ventas> Ventas { get; set; }
    
    }
}
