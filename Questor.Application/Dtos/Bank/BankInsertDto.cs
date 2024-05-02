namespace Questor.Application.Dtos.Bank
{
    public sealed record BankInsertDto(string Name,
                                       long Code,
                                       decimal PorcentageInterest);
}
