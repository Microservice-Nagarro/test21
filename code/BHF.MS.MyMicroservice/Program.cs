namespace BHF.MS.MyMicroservice
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            DependencyInjectionInitializers.AddKeyVaultIntegration(builder);
            DependencyInjectionInitializers.AddOptionsConfiguration(builder);
            DependencyInjectionInitializers.AddCustomServices(builder.Services);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            DependencyInjectionInitializers.AddApplicationInsights(builder);
            DependencyInjectionInitializers.AddHealthCheckConfiguration(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            DependencyInjectionInitializers.MapHealthChecks(app);

            await app.RunAsync();
        }
    }
}
