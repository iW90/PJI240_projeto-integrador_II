using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces;

namespace OrcamentoEletricoApp.Services
{
    public interface IImovelService
    {
        void Save(Imovel imovel);
    }

    public class ImovelService : IImovelService
    {
        private readonly IImovelRepository _imovelRepository;

        public ImovelService(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public void Save(Imovel imovel)
        {
            _imovelRepository.Add(imovel);
        }
    }
}
