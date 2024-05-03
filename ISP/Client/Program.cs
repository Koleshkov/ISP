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

            services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Add Services
            services.AddSingleton<IPassengerCardService, PassengerCardService>();

            //Add PageModels
            services.AddSingleton<PassengerCardPageModel>();
            services.AddSingleton<SendingListPageModel>();

            await builder.Build().RunAsync();
        }
    }
}