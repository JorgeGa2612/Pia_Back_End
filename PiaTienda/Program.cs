using PiaTienda;

var builder = WebApplication.CreateBuilder(args);

var startup = new StartUp(builder.Configuration);
startup.ConfigureServices(builder.Services);

var servicesLogger = (ILogger<StartUp>)app.Services.GetServices(typeof(ILogger<StartUp>));

var app = builder.Build();

startup.configure(app, app.Environment, servicesLogger);

app.Run();
