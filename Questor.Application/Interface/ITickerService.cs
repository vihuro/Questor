using Questor.Application.Dtos.Ticket;

namespace Questor.Application.Interface
{
    public interface ITickerService
    {
        Task<TicketGetDto> Insert(TicketInsertDto request, CancellationToken cancellationToken);
        Task<List<TicketGetDto>> GetAll(CancellationToken cancellationToken);
        Task<TicketGetDto> GetById(int id, CancellationToken cancellationToken);
    }
}
