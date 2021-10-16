using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GMapsServices.Api.Filters
{
    public class ServiceResultWrapper : ActionFilterAttribute, IResultFilter
    {
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult result)
            {
                result.Value = new { Data = result.Value };
            }

            return base.OnResultExecutionAsync(context, next);
        }
    }
}