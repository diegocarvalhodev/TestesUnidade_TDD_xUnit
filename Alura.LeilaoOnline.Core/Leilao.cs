using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoAntesDoPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }
    
    public class Leilao
    {
        private IList<Lance> _lances;
        private Interessada _cliente;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca)
        {
            this.Peca = peca;
            this._lances = new List<Lance>();
            this.Estado = EstadoLeilao.LeilaoAntesDoPregao;
        }

        private bool NovoLanceEhAceito(Interessada cliente, double valor)
            => (this.Estado == EstadoLeilao.LeilaoEmAndamento) && (this._cliente != cliente);

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceEhAceito(cliente, valor))
            {
                this._lances.Add(new Lance(cliente, valor));
                this._cliente = cliente;
            }
        }

        public void IniciaPregao() => this.Estado = EstadoLeilao.LeilaoEmAndamento;

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                var msg = "Não é possível terminar o pregão sem que ele tenha começado. Para isso, utiliza o método IniciaPregao().";
                throw new InvalidOperationException(msg);
            }   

            this.Ganhador = this.Lances
                                    .DefaultIfEmpty(new Lance(null, 0))
                                    .OrderBy(l => l.Valor)
                                    .LastOrDefault();

            this.Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
