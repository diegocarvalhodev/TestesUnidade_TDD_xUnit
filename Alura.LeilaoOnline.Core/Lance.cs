using System;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            this.Cliente = cliente;

            if (valor < 0)
                throw new ArgumentException("Valor do lance deve ser igual ou maior que zero.");

            this.Valor = valor;
        }
    }
}
