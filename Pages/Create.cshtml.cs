using HelpDeskLite.Models;
using HelpDeskLite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDeskLite.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TicketService _ticketService;

        public CreateModel(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = new Ticket();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ticketService.Crear(Ticket);

            return RedirectToPage("/Tickets/Index");
        }
    }
}