using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces;

namespace OrcamentoEletricoInfra.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly MyDbContext _context;

        public ImovelRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Add(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            _context.SaveChanges();
        }
    }
}
