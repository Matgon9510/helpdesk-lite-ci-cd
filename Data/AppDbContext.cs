using HelpDeskLite.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}