namespace VerificacionReportesNivel3.Server.DTOs
{
    public class ClienteResumenDto
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int CantidadFacturas { get; set; }
        public int ValorTotal { get; set; }
    }
}
