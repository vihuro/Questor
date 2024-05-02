using Microsoft.EntityFrameworkCore;
using Questor.Domain.Interface;
using Questor.Domain.Model;
using Questor.Persistence.Context;

namespace Questor.Persistence.Repository
{
    public class TicketRepository : BaseRepository<TicketModel>, ITicketRepository
    {
        public TicketRepository(AppDbContext context) : base(context)
        { }
        public override Task<TicketModel> GetById(int id, CancellationToken cancellationToken)
        {
            var result = _context.Tickets.Where(x => x.Id == id).Include(x => x.Bank).FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
