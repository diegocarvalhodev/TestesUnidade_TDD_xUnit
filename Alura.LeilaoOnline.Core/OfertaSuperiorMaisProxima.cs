using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; }

        public OfertaSuperiorMaisProxima(double valorDestino) => this.ValorDestino = valorDestino;

        public Lance Avalia(Leilao leilao)
            => leilao.Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .Where(l => l.Valor > this.ValorDestino)
                        .OrderBy(l => l.Valor)
                        .FirstOrDefault();
    }
}
