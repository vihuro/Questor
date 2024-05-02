using System.ComponentModel.DataAnnotations;

namespace Questor.Domain.Model
{
    public class BankModel : BaseModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "deve conter entre 3 e 50 caracteres", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public long Code { get; set; }
        [Required]
        public decimal PorcentageInterest { get; set; }
    }
}
