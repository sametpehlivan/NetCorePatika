using System.Text.Json;

namespace BookStore.WebApi.Middleware;

public class ExceptionMidlleware
{
    private readonly RequestDelegate _next;
   
    public ExceptionMidlleware(RequestDelegate next)
    {
        _next = next;

    }
    public async Task  Invoke(HttpContext context)
    {
        var request = context.Request;
        Console.WriteLine("Request : "+request.Method+" "+request.Path+" "+DateTime.UtcNow.ToLongTimeString());
        string message = "";
        try
        {
            await _next.Invoke(context);
            message =  "Response : "+request.Method+" "+request.Path+" "+" "+context.Response+" "+DateTime.UtcNow.ToLongTimeString();
            
        
        }
        catch(Exception ex)
        {
            message =  "Error : "+request.Method+" "+request.Path+" "+" "+ex.Message+" "+DateTime.UtcNow.ToLongTimeString();
            await HandleException(context,ex);
        
        }
        Console.WriteLine(message);
       
    }
    private  Task HandleException(HttpContext context,Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode =  StatusCodes.Status500InternalServerError;
        var errorResponse = JsonSerializer.Serialize(new {Error = ex.Message});
        return context.Response.WriteAsync(errorResponse);
    }

}