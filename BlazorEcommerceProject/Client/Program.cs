global using BlazorEcommerceProject.Shared;
global using System.Net.Http.Json;
global using BlazorEcommerceProject.Client.Services.ProductService;
global using BlazorEcommerceProject.Client.Services.CategoryService;
global using BlazorEcommerceProject.Client.Services.AuthService;
using BlazorEcommerceProject.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using BlazorEcommerceProject.Client.Services.CartService;;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

IServiceCollection serviceCollection = builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
await builder.Build().RunAsync();
