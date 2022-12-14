using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.WebApi.Filters;
public class ValidationFilters : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if(! context.ModelState.IsValid)
        {
            var errors = context.ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage)).ToList();
            throw new Exception(JsonSerializer.Serialize(errors)); 
        }
        await next();
    }
}