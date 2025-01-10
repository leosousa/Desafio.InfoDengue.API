using InfoDengue.API.Config;
using InfoDengue.Infraestrutura.BancoDados;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AdicionarDependenciasAplicacao();

builder.Services.AdicionarDependenciasDominio();

builder.Services.AdicionarDependenciasInfraestrutura(builder.Configuration);

builder.Services.AdicionarDependenciasServicoExterno(builder.Configuration);

var assemblies = new Assembly[] {
    Assembly.Load("InfoDengue.Dominio"),
    Assembly.Load("InfoDengue.Infraestrutura"),
    Assembly.Load("InfoDengue.Aplicacao")
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseServicoAtualizacaoBancoDados();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
