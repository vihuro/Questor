namespace Questor.Application.Dtos.Ticket
{
    public sealed record TicketInsertDto(string PayerName,
                                         string PayerCPF,
                                         string RecipientName,
                                         string RecipientCPF,
                                         decimal Value,
                                         DateTime DueDate,
                                         string? Observation,
                                         int BankId);
}
