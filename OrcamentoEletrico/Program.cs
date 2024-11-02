using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoInfra; // Namespace do seu DbContext
using OrcamentoEletricoApp.Services; // Namespace do seu serviço
using OrcamentoEletricoDomain.Interfaces; // Namespace da sua interface de repositório
using OrcamentoEletricoInfra.Repositories; // Namespace do seu repositório

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o banco de dados MySQL
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 2)) // Altere para a versão do seu MySQL
    ));

// Registrando repositórios e serviços
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddScoped<IImovelService, ImovelService>();

builder.Services.AddControllers(); // Adiciona suporte para controllers

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // Mapeia os endpoints de controllers

app.Run();
