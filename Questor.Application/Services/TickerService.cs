using AutoMapper;
using Questor.Application.Dtos.Ticket;
using Questor.Application.Interface;
using Questor.Application.Utils;
using Questor.Domain.Aux.Interfaces;
using Questor.Domain.Interface;
using Questor.Domain.Model;

namespace Questor.Application.Services
{
    public class TickerService : BaseService, ITickerService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankService _bankService;
        public TickerService(INotification notification,
                             ITicketRepository ticketRepository,
                             IMapper mapper,
                             IUnitOfWork unitOfWork,
                             IBankService bankService) : base(notification)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _bankService = bankService;
        }

        public async Task<List<TicketGetDto>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<List<TicketGetDto>>(await _ticketRepository.GetAll(cancellationToken));
        }

        public async Task<TicketGetDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _ticketRepository.GetById(id, cancellationToken);
            if(result != null) 
                result.Value = DateTime.UtcNow > result.DueDate ? result.Value + (result.Value  * result.Bank.PorcentageInterest) : result.Value;
            return _mapper.Map<TicketGetDto>(result);
        }

        public async Task<TicketGetDto> Insert(TicketInsertDto request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<TicketModel>(request);

            await Validations(entity, cancellationToken);
            if (!IsValidOperation()) return null;

            _ticketRepository.Insert(entity);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<TicketGetDto>(entity);

        }
        private async Task Validations(TicketModel entity, CancellationToken cancellationToken)
        {
            EntityIsValid(entity);
            var banckIsValid = await _bankService.GetById(entity.BankId, cancellationToken);
            if (banckIsValid == null) Notify("Banco invalido!");

        }
    }
}
