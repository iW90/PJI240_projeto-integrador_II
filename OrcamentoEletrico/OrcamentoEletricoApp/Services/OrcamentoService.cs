using AutoMapper;
using Microsoft.Extensions.Logging;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoDomain.Interfaces.Services;
using static OrcamentoEletricoDomain.Enums.ClassificacaoPadrao;

namespace OrcamentoEletricoApp.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly ILogger<OrcamentoService> _logger;
        private readonly IOrcamentoRepository _repository;

        public OrcamentoService(ILogger<OrcamentoService> logger, IOrcamentoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<decimal> gerarOrcamento(Imovel imovel)
        {
            try
            {
                var valor = calcularOrcamento(imovel);

                await _repository.AddImovel(imovel);

                _logger.LogInformation("Cadastro de projeto realizado com sucesso.");
                return valor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar imovel.");
                throw;
            }
        }

        public decimal calcularOrcamento(Imovel imovel)
        {
            decimal valorPorMetroQuadrado;

            switch (imovel.Classificacao)
            {
                case PadraoImovel.Baixo:
                    valorPorMetroQuadrado = 8m;
                    break;
                case PadraoImovel.Medio:
                    valorPorMetroQuadrado = 15m;
                    break;
                case PadraoImovel.Alto:
                    valorPorMetroQuadrado = 18m;
                    break;
                default:
                    _logger.LogInformation("Classificação inválida.");
                    throw new ArgumentException("Classificação inválida.");
            }

            _logger.LogInformation("Cálculo de orçamento realizado com sucesso.");
            return imovel.MetrosQuadrados * valorPorMetroQuadrado * imovel.NumeroDePavimentos;
        }
    }
}
