namespace Questor.Application.Dtos.Ticket
{
    public sealed record TicketInsertDto(string PayerName,
                                         string PayerCPFORCNPJ,
                                         string RecipientName,
                                         string RecipientCPFORCNPJ,
                                         decimal Value,
                                         DateTime DueDate,
                                         string? Observation,
                                         int BankId);
}
