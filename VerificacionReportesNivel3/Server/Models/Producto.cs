using System.ComponentModel.DataAnnotations;

namespace VerificacionReportesNivel3.Server.Models
{
    public class Producto
    {
        [Key]
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }
    }
}
