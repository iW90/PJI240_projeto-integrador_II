using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoInfra.Database;

namespace OrcamentoEletricoInfra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        // Cadastra um novo imóvel no banco
        public async Task AddPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        // Busca uma pessoa no banco através do email
        public async Task<Pessoa?> GetPessoaPorEmail(string email)
        {
            return await _context
                .Pessoas                    
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }
}
