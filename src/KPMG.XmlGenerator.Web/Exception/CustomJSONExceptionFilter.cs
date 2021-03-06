namespace KPMG.XmlGenerator.Web.Exception
{
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class CustomJSONExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.GetTypedHeaders().Accept.Any(header => header.MediaType.Value?.IndexOf("json") > -1))
            {
                context.Result = new JsonResult(new { error = context.Exception.Message })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
