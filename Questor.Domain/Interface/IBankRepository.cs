using Questor.Domain.Model;

namespace Questor.Domain.Interface
{
    public interface IBankRepository : IBaseRepository<BankModel>
    {
        Task<BankModel> GetByBankCode(long bankCode, CancellationToken cancellationToken);
    }
}
