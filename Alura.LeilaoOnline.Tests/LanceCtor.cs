using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorDeLanceNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            var excecaoObtida = Assert.Throws<ArgumentException>(
                                    //Act - método sobre teste
                                    () => new Lance(null, valorNegativo)
                                );

            //Assert
            var msgEsperada = "Valor do lance deve ser igual ou maior que zero.";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }


    }
}
