namespace pokedexApi.Initializers
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using pokedexData.Contexts;
    using pokedexApi.Configurations;

    public static partial class ServiceInitializer
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var mongoDbConfiguration = serviceProvider
                .GetRequiredService<IOptions<MongoDbConfiguration>>()
                .Value;

            // MongoDb
            services.AddSingleton<MongoDbContext>(_ =>
            {
                if (string.IsNullOrEmpty(mongoDbConfiguration.ConnectionString))
                {
                    throw new ArgumentException(
                        "MongoDbConfiguration:ConnectionString cannot be null or empty."
                    );
                }
                if (string.IsNullOrEmpty(mongoDbConfiguration.DatabaseName))
                {
                    throw new ArgumentException(
                        "MongoDbConfiguration:Database cannot be null or empty."
                    );
                }
                return new MongoDbContext(
                    mongoDbConfiguration.ConnectionString,
                    mongoDbConfiguration.DatabaseName
                );
            });
        }
    }
}