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
                Titulo = "Error en impresora",
                Descripcion = "El usuario no puede imprimir desde recepción.",
                Prioridad = "Alta",
                Estado = "Abierto",
                FechaCreacion = DateTime.Now
            },
            new Ticket
            {
                Id = 2,
                Titulo = "Equipo lento",
                Descripcion = "El equipo presenta lentitud al iniciar sesión.",
                Prioridad = "Media",
                Estado = "En proceso",
                FechaCreacion = DateTime.Now
            }
        };

        public List<Ticket> ObtenerTodos()
        {
            return Tickets
                .OrderByDescending(t => t.FechaCreacion)
                .ToList();
        }

        public Ticket? ObtenerPorId(int id)
        {
            return Tickets.FirstOrDefault(t => t.Id == id);
        }

        public void Crear(Ticket ticket)
        {
            ticket.Id = Tickets.Any() ? Tickets.Max(t => t.Id) + 1 : 1;
            ticket.FechaCreacion = DateTime.Now;
            ticket.Estado = "Abierto";

            Tickets.Add(ticket);
        }

        public void Actualizar(Ticket ticketActualizado)
        {
            var ticket = ObtenerPorId(ticketActualizado.Id);

            if (ticket == null)
            {
                return;
            }

            ticket.Titulo = ticketActualizado.Titulo;
            ticket.Descripcion = ticketActualizado.Descripcion;
            ticket.Prioridad = ticketActualizado.Prioridad;
            ticket.Estado = ticketActualizado.Estado;
        }

        public void CambiarEstado(int id, string estado)
        {
            var ticket = ObtenerPorId(id);

            if (ticket != null)
            {
                ticket.Estado = estado;
            }
        }

        public void Eliminar(int id)
        {
            var ticket = ObtenerPorId(id);

            if (ticket != null)
            {
                Tickets.Remove(ticket);
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

        public int TicketsEnProceso()
        {
            return Tickets.Count(t => t.Estado == "En proceso");
        }

        public int TicketsCerrados()
        {
            return Tickets.Count(t => t.Estado == "Cerrado");
        }
    }
}