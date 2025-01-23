var builder = WebApplication.CreateBuilder(args);

// Cria uma instância do Startup e passa a configuração
var startup = new Startup(builder.Configuration);

// Configura os serviços usando o método ConfigureServices do Startup
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configura o pipeline de middleware usando o método Configure do Startup
startup.Configure(app, app.Environment);

app.Run();