using HelpDeskLite.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public int TotalTickets { get; set; }
        public int TicketsAbiertos { get; set; }
        public int TicketsEnProceso { get; set; }
        public int TicketsCerrados { get; set; }

        public async Task OnGetAsync()
        {
            TotalTickets = await _context.Tickets.CountAsync();
            TicketsAbiertos = await _context.Tickets.CountAsync(t => t.Estado == "Abierto");
            TicketsEnProceso = await _context.Tickets.CountAsync(t => t.Estado == "En proceso");
            TicketsCerrados = await _context.Tickets.CountAsync(t => t.Estado == "Cerrado");
        }
    }
}