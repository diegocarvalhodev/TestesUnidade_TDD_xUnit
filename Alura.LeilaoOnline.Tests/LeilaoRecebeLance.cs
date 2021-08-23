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
        [Fact]
        public void NaoAceitaLancesConsecutivosDoMesmoCliente()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 200);

            //Act - método sobre teste
            leilao.RecebeLance(fulano, 300);

            //Assert
            var qtdEsperada = 1;
            var qtdLances = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdLances);
        }
        
        
        [Theory]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdEsperada, double[] ofertas)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            Interessada interessada = null;

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                
                if ((i%2)==0)
                    interessada = fulano;
                else
                    interessada = maria;
                
                leilao.RecebeLance(interessada, valor);
            }

            leilao.TerminaPregao();

            //Act - método sob teste
            //Testar se permite adicionar lanche após término do leilão
            if (interessada != fulano)
                leilao.RecebeLance(fulano, 1000);
            else
                leilao.RecebeLance(maria, 1000);


            //Assert
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObtida);
        }

    }
}
