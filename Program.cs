using HelpDeskLite.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddSingleton<TicketService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.MapGet("/health", () => "Aplicación HelpDeskLite funcionando correctamente");

app.MapGet("/api/tickets", (TicketService ticketService) =>
{
    return Results.Ok(ticketService.ObtenerTodos());
});

app.MapGet("/api/tickets/{id:int}", (int id, TicketService ticketService) =>
{
    var ticket = ticketService.ObtenerPorId(id);

    return ticket is not null ? Results.Ok(ticket) : Results.NotFound();
});

app.Run();