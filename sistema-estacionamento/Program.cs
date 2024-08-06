using Microsoft.OpenApi.Models;
using SistemaEstacionamento.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema Estacionamento", Version = "v1" });
});

// Registrar os serviços
builder.Services.AddSingleton<EstacionamentoService>();
builder.Services.AddSingleton<FuncionarioService>();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
