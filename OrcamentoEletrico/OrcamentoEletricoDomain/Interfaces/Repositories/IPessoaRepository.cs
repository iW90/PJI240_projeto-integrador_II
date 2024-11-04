using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoDomain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task AddPessoa(Pessoa pessoa);

        Task<Pessoa?> GetPessoaPorEmail(string email);
    }
}
