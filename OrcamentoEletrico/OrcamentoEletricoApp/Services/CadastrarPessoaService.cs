using AutoMapper;
using Microsoft.Extensions.Logging;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces;

namespace OrcamentoEletricoApp.Services
{
    public class CadastrarPessoaService : ICadastrarPessoaService
    {
        private readonly ILogger<CadastrarPessoaService> _logger;

        public CadastrarPessoaService(ILogger<CadastrarPessoaService> logger)
        {
            _logger = logger;
        }

        public async Task<int> cadastrarPessoa(Pessoa pessoa)
        {
            // buscar pessoa no banco de dados pelo e-mail
            // se existir, retorna o id dessa pessoa
            // se não existir, cadastra nova pessoa e retorna id
            var idPessoa = 1;

            _logger.LogInformation("Cálculo de orçamento realizado com sucesso.");
            return idPessoa;
        }
    }
}
