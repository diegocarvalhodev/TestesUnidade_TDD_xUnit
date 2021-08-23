using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }

        public Leilao(string peca)
        {
            this.Peca = peca;
            this._lances = new List<Lance>();
        }

        public void RecebeLance(Interessada cliente, double valor) => this._lances.Add(new Lance(cliente, valor));

        public void IniciaPregao()
        {

        }

        public void TerminaPregao() => this.Ganhador = this.Lances.OrderBy(l => l.Valor).Last();
    }
}
