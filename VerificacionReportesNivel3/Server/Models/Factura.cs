namespace VerificacionReportesNivel3.Server.Models
{
    public class Factura
    {
        public int NoFactura { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }

        // Relaciones de las tablas
        public Cliente ClienteNav { get; set; }
        public Producto ProductoNav { get; set; }
    }
}
