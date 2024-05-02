using Questor.Application.Dtos.Bank;

namespace Questor.Application.Interface
{
    public interface IBankService
    {
        Task<List<BankGetDto>> GetAll(CancellationToken cancellation);
        Task<BankGetDto> Insert(BankInsertDto request, CancellationToken cancellationToken);
        Task<BankGetDto> GetById(int id, CancellationToken cancellationToken);
        Task<BankGetDto> GetByBankCode(long bankCode, CancellationToken cancellationToken);

    }
}
