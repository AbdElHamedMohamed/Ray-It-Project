using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using BLL.ResourceFiles;

namespace BLL.Helper.Filters
{
    public class LanguageFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var language = context.HttpContext.Request.Headers["lang"];
            if (language.ToString().ToLower().Trim() == "ar")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Config.LangAr);
            else
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Config.LangEn);
            // execute any code before the action executes
            var result = await next();
            // execute any code after the action executes
        }
    }
}
