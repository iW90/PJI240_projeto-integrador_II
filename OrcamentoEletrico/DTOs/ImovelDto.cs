namespace OrcamentoEletrico.DTOs
{
    public class ImovelDto
    {
        public double MetrosQuadrados { get; set; }
        public int NumeroDePavimentos { get; set; }
        public string ClassificacaoDePadrao { get; set; }
        public int? QuantidadeDeTomadas { get; set; }
        public int? QuantidadeDePontosDeLuz { get; set; }
        public TimeSpan? Prazo { get; set; }
        public List<string> EquipamentosAdicionais { get; set; }
    }
}
