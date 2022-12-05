global using SalimBlazorECommerce.Client.Services.ProductService;
global using SalimBlazorECommerce.Client.Services.CategoryService;
global using SalimBlazorECommerce.Client.Services.AuthService;
global using SalimBlazorECommerce.Shared;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components.Authorization;
global using SalimBlazorECommerce.Client.Services.CartService;
global using SalimBlazorECommerce.Client.Services.OrderService;
global using SalimBlazorECommerce.Client.Services.AddressService;
global using SalimBlazorECommerce.Client.Services.ProductTypeService;
global using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalimBlazorECommerce.Client;
using Blazored.LocalStorage;
using BlazorEcommerce.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped< ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
