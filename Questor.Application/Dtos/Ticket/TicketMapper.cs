using AutoMapper;
using Questor.Domain.Model;

namespace Questor.Application.Dtos.Ticket
{
    public class TicketMapper : Profile
    {
        public TicketMapper() 
        {
            CreateMap<TicketInsertDto, TicketModel>();
            CreateMap<TicketModel, TicketGetDto>();
        }
    }
}
