using Microsoft.AspNetCore.Mvc;
using Questor.Application.Dtos.Ticket;
using Questor.Application.Interface;
using Questor.Domain.Aux.Interfaces;

namespace Questor.Api.Controllers
{
    [ApiController]
    [Route("api/v1/ticket")]
    public class TicketController : BaseController
    {
        private readonly ITickerService _tickerService;
        public TicketController(INotification notification,
                                ITickerService tickerService) : base(notification)
        {
            _tickerService = tickerService;
        }
        [HttpPost]
        public async Task<ActionResult<TicketGetDto>> Insert(TicketInsertDto request, CancellationToken cancellationToken)
        {
            try
            {
                return InsertEntityResponse(await _tickerService.Insert(request, cancellationToken));
            }
            catch (Exception ex)
            {

                return CustomResponseError(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketGetDto>> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return GetEntityResponse(await _tickerService.GetById(id, cancellationToken));
            }
            catch (Exception ex)
            {

                return CustomResponseError(ex.Message);
            }
        }
    }
}
