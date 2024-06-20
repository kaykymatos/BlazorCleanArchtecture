using BlazorCleanArchtecture.Livraria.Blazor.Components;
using BlazorCleanArchtecture.Livraria.Infrastructure.Context;
using BlazorCleanArchtecture.Livraria.CrossCutting.DependenciesApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
          .AddInteractiveServerComponents();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

CreateDatabase(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();

    var dataContext = serviceScope.ServiceProvider
                                  .GetService<ApplicationDbContext>();

    dataContext?.Database.EnsureCreated();
}
