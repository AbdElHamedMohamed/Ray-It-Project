using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper.Filters
{
    public class CustomValidationResponseFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var modelState in context.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                context.Result = new JsonResult(errors.First()) { StatusCode = 400/*Bad Request*/ };
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }
}
