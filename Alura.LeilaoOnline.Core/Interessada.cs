namespace Alura.LeilaoOnline.Core
{
    public class Interessada
    {
        public string Nome { get; }
        public Leilao Leilao { get; }

        public Interessada(string nome, Leilao leilao)
        {
            this.Nome = nome;
            this.Leilao = leilao;
        }
    }
}
