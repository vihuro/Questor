using Microsoft.EntityFrameworkCore;
using Questor.Domain.Model;

namespace Questor.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<BankModel> Banks { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
    }
}
