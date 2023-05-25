namespace PiaTienda.Entidades
{
    public class Ventas
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public int ClienteId { get; set; }
        public int Total { get; set; }
        public Clientes Clientes { get; set; }

      
    }
}
