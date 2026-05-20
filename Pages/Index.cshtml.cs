using HelpDeskLite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDeskLite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TicketService _ticketService;

        public IndexModel(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public int TotalTickets { get; set; }
        public int TicketsAbiertos { get; set; }
        public int TicketsEnProceso { get; set; }
        public int TicketsCerrados { get; set; }

        public void OnGet()
        {
            TotalTickets = _ticketService.TotalTickets();
            TicketsAbiertos = _ticketService.TicketsAbiertos();
            TicketsEnProceso = _ticketService.TicketsEnProceso();
            TicketsCerrados = _ticketService.TicketsCerrados();
        }
    }
}