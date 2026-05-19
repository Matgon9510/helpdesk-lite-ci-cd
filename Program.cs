using HelpDeskLite.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega Razor Pages
builder.Services.AddRazorPages();

// Configura la conexión a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuración del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Configuración de seguridad y rutas
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Archivos estáticos y Razor Pages
app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

// Endpoint de prueba para validar que la app funciona
app.MapGet("/health", () => "Aplicación HelpDesk Lite funcionando correctamente");

app.Run();