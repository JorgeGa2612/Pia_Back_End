using PiaTienda;

var builder = WebApplication.CreateBuilder(args);

var startup = new StartUp(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

var serviceLogger = (ILogger<StartUp>)app.Services.GetService(typeof(ILogger<StartUp>));

startup.configure(app, app.Environment, serviceLogger);

app.Run();
