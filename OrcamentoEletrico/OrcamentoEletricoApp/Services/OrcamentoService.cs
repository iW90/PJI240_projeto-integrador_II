using AutoMapper;
using Microsoft.Extensions.Logging;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces;
using static OrcamentoEletricoDomain.Enums.ClassificacaoPadrao;

namespace OrcamentoEletricoApp.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly ILogger<OrcamentoService> _logger;

        public OrcamentoService(ILogger<OrcamentoService> logger)
        {
            _logger = logger;
        }

        public async Task<decimal> gerarOrcamento(Imovel imovel)
        {
            var valor = calcularOrcamento(imovel);

            //cadastrar imovel

            _logger.LogInformation("Cadastro de projeto realizado com sucesso.");
            return valor;
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
