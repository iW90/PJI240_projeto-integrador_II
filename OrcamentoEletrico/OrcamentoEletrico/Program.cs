using Microsoft.OpenApi.Models;
using OrcamentoEletricoApp.Mappings;
using OrcamentoEletricoApp.Services;
using OrcamentoEletricoDomain.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configure Logger
builder.Services.AddLogging(builder => builder.AddConsole());

// Configure Dependency Injection
builder.Services.AddScoped<ICadastrarPessoaService, CadastrarPessoaService>();
builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();





// Configure the DbContext (EFCore).
//var conectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");

//builder.Services.AddDbContext<DbContext>(options =>
//   options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));


// Configura��es para Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();