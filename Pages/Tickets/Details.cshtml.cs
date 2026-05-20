using HelpDeskLite.Models;
using HelpDeskLite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDeskLite.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly TicketService _ticketService;

        public DetailsModel(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

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
    }
}