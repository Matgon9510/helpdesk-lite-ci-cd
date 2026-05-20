using HelpDeskLite.Models;
using HelpDeskLite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDeskLite.Pages.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly TicketService _ticketService;

        public DeleteModel(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = new Ticket();

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.ObtenerPorId(id.Value);

            if (ticket == null)
            {
                return NotFound();
            }

            Ticket = ticket;

            return Page();
        }

        public IActionResult OnPost()
        {
            _ticketService.Eliminar(Ticket.Id);

            return RedirectToPage("./Index");
        }
    }
}