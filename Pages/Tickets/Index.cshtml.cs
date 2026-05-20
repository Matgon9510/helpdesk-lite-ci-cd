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

        public void OnGet()
        {
            Tickets = _ticketService.ObtenerTodos();
        }

        public IActionResult OnPostCambiarEstado(int id, string estado)
        {
            _ticketService.CambiarEstado(id, estado);
            return RedirectToPage("./Index");
        }
    }
}