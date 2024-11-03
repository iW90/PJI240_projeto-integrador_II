using static OrcamentoEletricoDomain.Enums.ClassificacaoPadrao;

namespace OrcamentoEletrico.Models.Requests
{
    public class ImovelRequest
    {
        public int PessoaId { get; set; }
        public int MetrosQuadrados { get; set; }
        public int NumeroDePavimentos { get; set; }
        public PadraoImovel Classificacao { get; set; }
    }
}
