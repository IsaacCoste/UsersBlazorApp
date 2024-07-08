using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UserBlazorApp.UI;
using UserBlazorApp.UI.Services;
using UsersBlazorApp.Data.Interfacez;
using UsersBlazorApp.Data.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7097/") });
builder.Services.AddScoped<CService<AspNetUsers>, UserClieService>();

await builder.Build().RunAsync();
