using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoInfra; // Namespace do seu DbContext
using OrcamentoEletricoApp.Services; // Namespace do seu servi�o
using OrcamentoEletricoDomain.Interfaces; // Namespace da sua interface de reposit�rio
using OrcamentoEletricoInfra.Repositories; // Namespace do seu reposit�rio

var builder = WebApplication.CreateBuilder(args);

// Configura��o da conex�o com o banco de dados MySQL
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 2)) // Altere para a vers�o do seu MySQL
    ));

// Registrando reposit�rios e servi�os
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddScoped<IImovelService, ImovelService>();

builder.Services.AddControllers(); // Adiciona suporte para controllers

var app = builder.Build();

// Configura��o do pipeline de requisi��es
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
