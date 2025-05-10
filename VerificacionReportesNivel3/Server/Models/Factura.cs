using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerificacionReportesNivel3.Server.Models
{
    public class Factura
    {
        [Key, Column(Order = 0)]
        public int NoFactura { get; set; }
        [Key, Column(Order = 1)]
        public string Producto { get; set; }
        public string Cliente { get; set; }

        // Relaciones de las tablas
        [ForeignKey("Cliente")]
        public Cliente ClienteNav { get; set; }
        [ForeignKey("Producto")]
        public Producto ProductoNav { get; set; }
    }
}
