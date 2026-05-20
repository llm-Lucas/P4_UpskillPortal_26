using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.App.Data;
using PortalUpskill.App.Utils;
using PortalUpskill.App.Shared;
using Plk.Blazor.DragDrop;
using Radzen;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using UpskillPortal.Utils;
using PortalUpskill.Data.DataAccessDapper.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazorDragDrop();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncFusionLocalizer));

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("pt-PT")
    };

    options.DefaultRequestCulture = new RequestCulture("pt-PT");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// App-specific services
builder.Services.AddScoped<AuthenticationStateProvider, UpskillAuthenticationStateProvider>();
builder.Services.AddScoped<RefreshService>();
builder.Services.AddScoped<IAulaData, AulaData>();
builder.Services.AddScoped<IFaltaData, FaltaData>();
builder.Services.AddScoped<IModuloData, ModuloData>();
builder.Services.AddScoped<ICursoData, CursoData>();
builder.Services.AddScoped<IPessoaData, PessoaData>();
builder.Services.AddScoped<IPessoalData, PessoalData>();
builder.Services.AddScoped<IFormadorData, FormadorData>();
builder.Services.AddScoped<IFormandoData, FormandoData>();
builder.Services.AddScoped<ITurmaData, TurmaData>();
builder.Services.AddScoped<ICNAEFData, CNAEFData>();
builder.Services.AddScoped<IHabilitacoesData, HabilitacoesData>();
builder.Services.AddScoped<IPaisesData, PaisesData>();
builder.Services.AddScoped<IFuncoesData, FuncoesData>();
builder.Services.AddScoped<ICoordenadorFormadorData, CoordenadorFormadorData>();
builder.Services.AddScoped<IListaEstadosFormandoData, ListaEstadosFormandoData>();
builder.Services.AddScoped<IListaEstadosFormadorData, ListaEstadosFormadorData>();
builder.Services.AddScoped<IAvaliacaoModularData, AvaliacaoModularData>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<FileManagerService>();
builder.Services.AddScoped<HashingService>();
builder.Services.AddScoped<IAnoLetivoData, AnoLetivoData>();
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDIwNTk2QDMxMzkyZTMxMmUzMFlqM1Arc2tlUE1TZmVkSi9rU2NKNUxvSDdCT0duNFcrZGdQTTEwMlhEUms9");

// Middleware
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
