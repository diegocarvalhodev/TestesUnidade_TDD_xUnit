using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoEmAndamento,
        LeilaoFinalizado
    }
    
    
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca)
        {
            this.Peca = peca;
            this._lances = new List<Lance>();
            this.Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (this.Estado == EstadoLeilao.LeilaoEmAndamento)
                this._lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {

        }

        public void TerminaPregao()
        {
            this.Ganhador = this.Lances
                                    .DefaultIfEmpty(new Lance(null, 0))
                                    .OrderBy(l => l.Valor)
                                    .LastOrDefault();

            this.Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
