namespace MinimalApi.Helpers
{
    public class ResultHelper
    {
        public static IResult NotFound(
            int id,
            string message = "Registro não encontrado")
        {

            var response = new
            {
                Id = id,
                Message = message,
            };

            return Results.NotFound(response);
        }
    }
}