using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoDomain.Interfaces
{
    public interface ICadastrarPessoaService
    {
        Task<int> cadastrarPessoa(Pessoa pessoa);
    }
}
