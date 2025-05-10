using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerificacionReportesNivel3.Server.Models
{
    public class Verificacion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CedulaCliente { get; set; }
        public bool ContieneNombre { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        //Relación de Tabla Cliente
        [ForeignKey("CedulaCliente")]
        public Cliente ClienteNav { get; set; }
    }
}
