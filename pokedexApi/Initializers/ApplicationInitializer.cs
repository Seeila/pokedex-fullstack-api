namespace pokedexApi.Initializers
{
    public static partial class ApplicationInitializer
    {
        public static void InitializeApplication(this WebApplication app)
        {
            if(app.Environment.IsDevelopment())
            {
                 app.UseCors("EnableDevCORS");

                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHttpsRedirection();
        }
    }
}