using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Helpers
{
    public static class ValidationHelper
    {
        public static IResult? Validate<T>(T dto)
        {
            if (dto == null) return Results.BadRequest(new { Message = "Invalid data", Errors = new Dictionary<string, string[]>() });

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(dto);

            if (!Validator.TryValidateObject(dto, context, validationResults, true))
            {
                var errors = validationResults.ToDictionary(
                    k => k.MemberNames.FirstOrDefault() ?? "Error",
                    v => new string[] { v.ErrorMessage! });

                return Results.BadRequest(new { Message = "Validation failed", Errors = errors });
            }

            return null;
        }
    }

}