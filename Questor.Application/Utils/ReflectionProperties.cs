using System.ComponentModel.DataAnnotations;

namespace Questor.Application.Utils
{
    public static class ReflectionProperties
    {
        public static bool IsValid(this object entity)
        {
            var context = new ValidationContext(entity, null, null);
            var result = new List<ValidationResult>();


            var validations = Validator.TryValidateObject(entity, context, result, true);

            return validations;
        }
        public static IEnumerable<ValidationResult> GetValidationErros(this object entity)
        {
            var validationResult = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, context, validationResult, true);
            return validationResult;
        }
    }
}
