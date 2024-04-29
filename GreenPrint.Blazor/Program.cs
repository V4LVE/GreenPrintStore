using Blazored.SessionStorage;
using GreenPrint.Blazor;
using GreenPrint.Blazor.Service.Intefaces;
using GreenPrint.Blazor.Service.Services;
using GreenPrint.Blazor.Utility;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7131"), DefaultRequestHeaders = { { "apikey", "12345" } } });

builder.Services.AddBlazoredSessionStorageAsSingleton();

#region IndexedDb
builder.Services.AddScoped<IndexedDbAccessor>();
builder.Services.AddScoped<CookieAccessor>();
builder.Services.AddScoped<LocalStorage>();

var host = builder.Build();
using var scope = host.Services.CreateScope();
await using var indexedDB = scope.ServiceProvider.GetService<IndexedDbAccessor>();

if (indexedDB is not null)
{
    await indexedDB.InitializeAsync();
}
#endregion

#region DI Container

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IWarehouseItemService, WarehouseItemService>();
builder.Services.AddScoped<IImageService, ImageService>();

// Radzen Services
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();

#endregion

await builder.Build().RunAsync();
