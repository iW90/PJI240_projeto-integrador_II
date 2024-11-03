using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoDomain.Interfaces
{
    public interface IOrcamentoService
    {
        Task<decimal> gerarOrcamento(Imovel imovel);
    }
}
