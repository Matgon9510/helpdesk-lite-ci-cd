using HelpDeskLite.Data;
using HelpDeskLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLite.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();

        public async Task OnGetAsync()
        {
            Tickets = await _context.Tickets
                .OrderByDescending(t => t.FechaCreacion)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCambiarEstadoAsync(int id, string estado)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            ticket.Estado = estado;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}