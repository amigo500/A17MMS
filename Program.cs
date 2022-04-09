using A17MMS.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;


namespace A17MMS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient<IMachineDataService, MachineDataService>(client =>
                //client.BaseAddress = new Uri("http://localhost:7071/")); //Local
                client.BaseAddress = new Uri("https://msfuncapi.azurewebsites.net/")); //Production

            await builder.Build().RunAsync();
        }
    }
}