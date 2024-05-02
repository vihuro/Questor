using Questor.Domain.Model;

namespace Questor.Application.Dtos.Ticket
{
    public class TicketGetDto : BaseDto
    {
        public string PayerName { get; set; }
        public string PayerCPFORCNPJ { get; set; }
        public string RecipientName { get; set; }
        public string RecipientCPFORCNPJ { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public string Observation { get; set; }
        public int BankId { get; set; }
    }
}
