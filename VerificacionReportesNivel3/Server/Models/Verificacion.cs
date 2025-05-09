namespace VerificacionReportesNivel3.Server.Models
{
    public class Verificacion
    {
        public int Id { get; set; }
        public string CedulaCliente { get; set; }
        public bool ContieneNombre { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        //Relación de Tabla Cliente
        public Cliente ClienteNav { get; set; }
    }
}
