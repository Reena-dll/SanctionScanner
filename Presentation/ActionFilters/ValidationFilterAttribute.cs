﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Presentation.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) // Metot çalışmadan önce olan virtual metodunu eziyoruz.
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"]; // Route datayı okuyarak controller ve endpoint bilgisini alıyoruz.

            // Dto yakalama

            var param = context.ActionArguments
                .SingleOrDefault(p => p.Value.ToString().Contains("Dto")).Value;

            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. " +
                    $"Controller : {controller} " +
                    $"Action : {action}");
                return;
            }

            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);

            
        }
    }
}