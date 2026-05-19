using HelpDeskLite.Data;
using HelpDeskLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLite.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = new Ticket();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }

            Ticket = ticket;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var ticketDb = await _context.Tickets.FindAsync(Ticket.Id);

            if (ticketDb == null)
            {
                return NotFound();
            }

            ticketDb.Titulo = Ticket.Titulo;
            ticketDb.Descripcion = Ticket.Descripcion;
            ticketDb.Prioridad = Ticket.Prioridad;
            ticketDb.Estado = Ticket.Estado;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}