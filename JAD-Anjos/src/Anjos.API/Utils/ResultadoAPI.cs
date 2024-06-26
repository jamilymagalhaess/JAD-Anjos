using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Anjos.API.Utils;

public static class ResultadoAPI
{
    public static async Task<IActionResult> Resultado<T>(this Task<T> task)
    {
        try
        {
            var result = await task;
            return new OkObjectResult(result);
        }
        catch (KeyNotFoundException ex)
        {
            return new NotFoundObjectResult(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }
    }
}
