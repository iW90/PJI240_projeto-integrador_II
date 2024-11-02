namespace OrcamentoEletricoDomain.Entities
{
    public class Imovel
    {
        public double MetrosQuadrados { get; private set; }
        public int NumeroDePavimentos { get; private set; }
        public string ClassificacaoDePadrao { get; private set; }
        public int? QuantidadeDeTomadas { get; private set; }
        public int? QuantidadeDePontosDeLuz { get; private set; }
        public TimeSpan? Prazo { get; private set; }
        public List<string> EquipamentosAdicionais { get; private set; } = new List<string>();

        public Imovel(double metrosQuadrados, int numeroDePavimentos, string classificacaoDePadrao)
        {
            if (metrosQuadrados <= 0) throw new ArgumentException("Metros quadrados deve ser maior que zero.");
            if (numeroDePavimentos <= 0) throw new ArgumentException("Número de pavimentos deve ser maior que zero.");
            if (string.IsNullOrWhiteSpace(classificacaoDePadrao)) throw new ArgumentException("Classificação de padrão é obrigatória.");

            MetrosQuadrados = metrosQuadrados;
            NumeroDePavimentos = numeroDePavimentos;
            ClassificacaoDePadrao = classificacaoDePadrao;
        }

        public void SetQuantidadeDeTomadas(int? quantidadeDeTomadas) => QuantidadeDeTomadas = quantidadeDeTomadas;
        public void SetQuantidadeDePontosDeLuz(int? quantidadeDePontosDeLuz) => QuantidadeDePontosDeLuz = quantidadeDePontosDeLuz;
        public void SetPrazo(TimeSpan? prazo) => Prazo = prazo;

        public void AdicionarEquipamentoAdicional(string equipamento)
        {
            if (!string.IsNullOrWhiteSpace(equipamento))
            {
                EquipamentosAdicionais.Add(equipamento);
            }
        }
    }
}
