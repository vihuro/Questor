using AutoMapper;
using Questor.Domain.Model;

namespace Questor.Application.Dtos.Bank
{
    public class BankMapper : Profile
    {
        public BankMapper() 
        {
            CreateMap<BankModel, BankGetDto>();
            CreateMap<BankInsertDto, BankModel>();
        }
    }
}
