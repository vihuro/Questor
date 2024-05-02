using Microsoft.AspNetCore.Mvc;
using Questor.Application.Dtos.Bank;
using Questor.Application.Interface;
using Questor.Domain.Aux.Interfaces;

namespace Questor.Api.Controllers
{
    [ApiController]
    [Route("api/v1/bank")]
    public class BankController : BaseController
    {
        private readonly IBankService _bankService;

        public BankController(INotification notification,
                              IBankService bankService) : base(notification)
        {
            _bankService = bankService;
        }

        [HttpGet("{bankCode}")]
        public async Task<ActionResult<BankGetDto>> GetByBankCode([FromRoute]long bankCode, CancellationToken cancellationToken)
        {
            try
            {
                return GetEntityResponse(await _bankService.GetByBankCode(bankCode, cancellationToken));
            }
            catch (Exception ex)
            {

                return CustomResponseError(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<BankGetDto>> Insert(BankInsertDto request,
                                                           CancellationToken cancellationToken)
        {
            try
            {
                return InsertEntityResponse(await _bankService.Insert(request, cancellationToken));

            }
            catch (Exception ex)
            {

                return CustomResponseError(ex.Message);
            }
        }
    }
}
