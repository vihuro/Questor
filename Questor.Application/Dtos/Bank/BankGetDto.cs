namespace Questor.Application.Dtos.Bank
{
    public  class BankGetDto : BaseDto
    {
        public string Name { get; set; }
        public long Code { get; set; }
        public decimal PorcentageInterest { get; set; }
    }
}
