using GreenPrint.Blazor;
using GreenPrint.Blazor.Service.Intefaces;
using GreenPrint.Blazor.Service.Services;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region DI Container

builder.Services.AddScoped<ICategoryService, CategoryService>();

#endregion

await builder.Build().RunAsync();
