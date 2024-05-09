namespace Talabat.APIs.Extenstions
{
    public static class SwaggerServicesExtention
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {

           Services.AddEndpointsApiExplorer();
           Services.AddSwaggerGen();

            return Services;
        }

        public static WebApplication UseSwaggerMiddlewares(this WebApplication app) {

            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
