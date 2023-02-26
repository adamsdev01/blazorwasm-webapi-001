using BlazorVinyls.Client;
using BlazorVinyls.Client.HttpRepository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7092/api/") });
builder.Services.AddScoped<IVinylHttpRepository, VinylHttpRepository>();
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);

await builder.Build().RunAsync();
