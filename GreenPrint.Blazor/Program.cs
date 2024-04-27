using GreenPrint.Blazor;
using GreenPrint.Blazor.Service.Intefaces;
using GreenPrint.Blazor.Service.Services;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7131"), DefaultRequestHeaders = { { "apikey", "12345" } } });

//builder.Services.AddHttpClient<HttpClient>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7131/");
//});

#region DI Container

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IWarehouseItemService, WarehouseItemService>();

// Radzen Services
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();

#endregion

await builder.Build().RunAsync();
