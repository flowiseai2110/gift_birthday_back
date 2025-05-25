namespace WEB.API.ECOMMERCE.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ValidationMiddleware>();
        }
    }
}
