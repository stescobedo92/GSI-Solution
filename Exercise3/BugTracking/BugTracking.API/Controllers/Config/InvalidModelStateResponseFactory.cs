using BugTracking.API.Extensions;
using BugTracking.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.API.Controllers.Config
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);
            
            return new BadRequestObjectResult(response);
        } 
    }
}