using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdEsperada, double[] ofertas)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            
            leilao.TerminaPregao();

            //Act - método sob teste
            //Testar se permite adicionar lanche após término do leilão
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObtida);
        }

    }
}
