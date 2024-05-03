using ISP.PageModels;
using ISP.Services.PassengerCardServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ISP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Add Services
            services.AddTransient<IPassengerCardService, PassengerCardService>();

            //Add PageModels
            services.AddTransient<PassengerCardPageModel>();
            services.AddTransient<SendingListPageModel>();

            await builder.Build().RunAsync();
        }
    }
}