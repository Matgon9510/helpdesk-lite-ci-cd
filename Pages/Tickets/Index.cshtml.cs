using HelpDeskLite.Models;
using HelpDeskLite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDeskLite.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly TicketService _ticketService;

        public IndexModel(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();

        [BindProperty(SupportsGet = true)]
        public string? EstadoFiltro { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PrioridadFiltro { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Busqueda { get; set; }

        public void OnGet()
        {
            var tickets = _ticketService.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(EstadoFiltro))
            {
                tickets = tickets
                    .Where(t => t.Estado.Equals(EstadoFiltro, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(PrioridadFiltro))
            {
                tickets = tickets
                    .Where(t => t.Prioridad.Equals(PrioridadFiltro, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(Busqueda))
            {
                tickets = tickets
                    .Where(t =>
                        t.Titulo.Contains(Busqueda, StringComparison.OrdinalIgnoreCase) ||
                        t.Descripcion.Contains(Busqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            Tickets = tickets;
        }

        public IActionResult OnPostCambiarEstado(int id, string estado)
        {
            _ticketService.CambiarEstado(id, estado);
            return RedirectToPage("./Index");
        }
    }
}