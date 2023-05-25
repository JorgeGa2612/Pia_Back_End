using PiaTienda;

var builder = WebApplication.CreateBuilder(args);

var startup = new StartUp(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.configure(app, app.Environment);

app.Run();
