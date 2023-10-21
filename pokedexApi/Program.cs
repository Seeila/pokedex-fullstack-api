using pokedexApi.Initializers;

var builder = WebApplication.CreateBuilder(args);

builder.InitializeConfigurations();
builder.Services.InitializeServices();

var app = builder.Build();


app.Run();
