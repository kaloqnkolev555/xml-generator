namespace KPMG.XmlGenerator.Web.Exception
{
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Filters;

    using Serilog;

    /// <summary>
    /// GlobalExceptionFilter class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        public void OnException(ExceptionContext context)
        {
            // Build log message
            var sb = new StringBuilder();
            sb.AppendLine("Unhandled exception.");
            sb.AppendLine($"User: {context.HttpContext.User?.Identity?.Name}.");
            sb.AppendLine($"Method: {context.HttpContext.Request.Method}.");
            sb.AppendLine($"Path: {context.HttpContext.Request.Path}.");

            sb.AppendLine("Headers: ");
            foreach (var header in context.HttpContext.Request.Headers)
            {
                sb.AppendLine($"     {header.Key}: {header.Value}");
            }

            // Log error
            Log.Error(sb.ToString(), context.Exception);
        }
    }
}
