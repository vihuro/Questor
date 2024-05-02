using Microsoft.EntityFrameworkCore;
using Questor.Domain.Aux;
using Questor.Domain.Aux.Interfaces;
using Questor.Domain.Interface;
using Questor.Domain.Model;
using Questor.Persistence.Context;

namespace Questor.Persistence.Repository
{
    public class BankRepository : BaseRepository<BankModel>, IBankRepository
    {
        private readonly INotification _notification;
        public BankRepository(AppDbContext context, 
                              INotification notification) : base(context)
        {
            _notification = notification;
        }

        public async Task<BankModel> GetByBankCode(long bankCode, CancellationToken cancellationToken)
        {
            return await _context.Banks.Where(x => x.Code == bankCode).FirstOrDefaultAsync(cancellationToken);
        }
        public override BankModel Insert(BankModel entity)
        {
            var bankExisting = _context.Banks.Where(x => x.Code == entity.Code).FirstOrDefault();
            if (bankExisting != null) 
            {
                _notification.Handle(new Notification("Já existe um banco com esse código"));
                return null;
            } 

            return base.Insert(entity);
        }
    }
}
