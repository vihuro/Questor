using AutoMapper;
using Questor.Application.Dtos.Bank;
using Questor.Application.Interface;
using Questor.Application.Utils;
using Questor.Domain.Aux.Interfaces;
using Questor.Domain.Interface;
using Questor.Domain.Model;

namespace Questor.Application.Services
{
    public class BankService : BaseService, IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankService(INotification notification,
                           IBankRepository bankRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper) : base(notification)
        {
            _bankRepository = bankRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BankGetDto>> GetAll(CancellationToken cancellation)
        {
            var entity = await _bankRepository.GetAll(cancellation);
            var result = _mapper.Map<List<BankGetDto>>(entity);

            return result;
        }

        public async Task<BankGetDto> GetByBankCode(long bankCode, CancellationToken cancellationToken)
        {
            return _mapper.Map<BankGetDto>(await _bankRepository.GetByBankCode(bankCode, cancellationToken));
        }

        public async Task<BankGetDto> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<BankGetDto>(await _bankRepository.GetById(id, cancellationToken));
        }

        public async Task<BankGetDto> Insert(BankInsertDto request,
                                             CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BankModel>(request);
            await Validations(entity, cancellationToken);




            _bankRepository.Insert(entity);
            if (!IsValidOperation()) return null;

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<BankGetDto>(entity);
        }
        private async Task Validations(BankModel model, CancellationToken cancellationToken)
        {
            EntityIsValid(model);
        }
    }
}
