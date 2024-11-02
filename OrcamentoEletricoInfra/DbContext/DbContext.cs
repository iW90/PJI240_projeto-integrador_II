using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoDomain.Entities;
using System.Collections.Generic;

namespace OrcamentoEletricoInfra
{
    public class MyDbContext : DbContext
    {
        public DbSet<Imovel> Imoveis { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    }
}
