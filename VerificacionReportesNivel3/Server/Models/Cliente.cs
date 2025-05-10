using System.ComponentModel.DataAnnotations;

namespace VerificacionReportesNivel3.Server.Models
{
    public class Cliente
    {
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
