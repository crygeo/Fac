using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServidorFac;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<Servidor>();
        services.AddMvc(options => options.EnableEndpointRouting = false);
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseMvc();
    }
}
