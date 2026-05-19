using HelpDeskLite.Models;

namespace HelpDeskLite.Services
{
    public class TicketService
    {
        private static readonly List<Ticket> Tickets = new()
        {
            new Ticket
            {
                Id = 1,
                Titulo = "Equipo lento",
                Descripcion = "El equipo presenta lentitud al iniciar sesión.",
                Prioridad = "Media",
                Estado = "Abierto"
            },
            new Ticket
            {
                Id = 2,
                Titulo = "Error en Outlook",
                Descripcion = "El usuario no puede enviar correos desde Outlook.",
                Prioridad = "Alta",
                Estado = "En proceso"
            }
        };

        public List<Ticket> ObtenerTodos()
        {
            return Tickets;
        }

        public void Crear(Ticket ticket)
        {
            ticket.Id = Tickets.Count + 1;
            ticket.FechaCreacion = DateTime.Now;
            ticket.Estado = "Abierto";

            Tickets.Add(ticket);
        }

        public void CambiarEstado(int id, string nuevoEstado)
        {
            var ticket = Tickets.FirstOrDefault(t => t.Id == id);

            if (ticket != null)
            {
                ticket.Estado = nuevoEstado;
            }
        }

        public int TotalTickets()
        {
            return Tickets.Count;
        }

        public int TicketsAbiertos()
        {
            return Tickets.Count(t => t.Estado == "Abierto");
        }

        public int TicketsCerrados()
        {
            return Tickets.Count(t => t.Estado == "Cerrado");
        }
    }
}