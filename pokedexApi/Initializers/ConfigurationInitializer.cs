namespace pokedexApi.Initializers
{
    using pokedexApi.Configurations;
    public static partial class ConfigurationInitializer
    {
        public static void InitializeConfigurations(this WebApplicationBuilder builder )
        {
            builder.Services.Configure<MongoDbConfiguration>(
                builder.Configuration.GetSection("MongoDbConfiguration")
            );
        }
    }
}