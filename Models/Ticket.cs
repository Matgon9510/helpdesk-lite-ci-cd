namespace HelpDeskLite.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Prioridad { get; set; } = "Media";

        public string Estado { get; set; } = "Abierto";

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}