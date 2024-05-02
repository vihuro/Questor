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
        [StringLength(18, ErrorMessage = "deve conter entre 14 e 18 Caracteres", MinimumLength = 14)]
        [ValidationCPForCNPJ(ErrorMessage = "Não é um CPF ou CNPJ valido")]
        public string PayerCPFORCNPJ { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "deve conter entre 3 e 50 caracteres", MinimumLength = 3)]
        public string RecipientName { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "deve conter entre 14 e 18 Caracteres", MinimumLength = 14)]
        [ValidationCPForCNPJ(ErrorMessage ="Não é um CPF ou CNPJ valido")]
        public string RecipientCPFORCNPJ { get; set; }
        [Required]
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        [MaxLength(100,ErrorMessage = "deve conter no maximo 100 caracteres")]
        public string Observation { get; set; }
        [Required]
        public int BankId { get; set; }
        public virtual BankModel Bank { get; set; }
    }
}
