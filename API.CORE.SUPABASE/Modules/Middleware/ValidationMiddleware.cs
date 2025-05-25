using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Web.Api.UseCases.Common.Bases;
using Web.Api.UseCases.Common.Exceptions;

namespace WEB.API.ECOMMERCE.Modules.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context) {
            try
            {
                await _next.Invoke(context);
            }
            catch ( ValidationExceptionCustom ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<Object> { Message = "Errores de validacion", Errors = ex.Errors });
            }
        }
    }
}
