using Questor.Domain.Utils;
using System.ComponentModel.DataAnnotations;
namespace Questor.Domain.Model
{
    public class TicketModel : BaseModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "deve conter entre 3 e 50 caracteres", MinimumLength = 3)]
        public string PayerName { get; set; }
        [Required]
        [ValidationCPForCNPJ(ErrorMessage = "Não é um CPF ou CNPJ valido")]
        public string PayerCPF { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "deve conter entre 3 e 50 Caracteres", MinimumLength = 3)]
        public string RecipientName { get; set; }
        [Required]
        [ValidationCPForCNPJ(ErrorMessage ="Não é um CPF ou CNPJ valido")]
        public string RecipientCPF { get; set; }
        [Required]
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public string Observation { get; set; }
        [Required]
        public int BankId { get; set; }
        public virtual BankModel Bank { get; set; }
    }
}
