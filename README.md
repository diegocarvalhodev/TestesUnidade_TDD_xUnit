# Testes de Unidade e TDD com xUnit.
Projeto para estudar Testes de Unidade e TDD com xUnit para projetos C#.NET
<br><br>

## Entendendo o negócio
O negócio que queremos implementar é um sistema de leilões. Alguns conceitos iniciais aos quais vamos nos basear:

- Um Leilão é uma promessa de venda de uma peça específica para o cliente que der o melhor lance.
- Um cliente é uma pessoa física interessada em fazer ofertas no leilão.
- Os lances são ofertados dentro de em um período pré-determinado chamado pregão. Os lances devem ser aceitos segundo regras específicas determinadas no leilão.
- Quando o pregão termina é determinado um ganhador (do leilão) baseado nos critérios estabelecidos para aquele leilão. O critério mais comum é o maior valor ofertado.
<br>

### Avaliar a melhor oferta de um leilão
A melhor oferta de um leilão é o maior valor dentre os lances do leilão.

### Cenários

#### Cenário 1
- **Dado** leilão com pelo menos um lance<br>
- **Quando** o pregão/leilão termina<br>
- **Então** o valor esperado é o maior valor dado como lance
	e o cliente ganhador é aquele que deu o maior lance

#### Cenário 2
- **Dado** leilão sem qualquer lance<br>
- **Quando** o pregão/leilão termina<br>
- **Então** o valor do lance ganhador é Zero

#### Cenário 3
- **Dado** leilão finalizado com X lances<br>
- **Quando** leilão recebe nova oferta de lance<br>
- **Então** a quantidade de lances continua sendo X e novo lance é ignorado

#### Cenário 4
- **Dado** um leilão ainda sem ter iniciado um pregão/leilão<br>
- **Quando** leilão recebe qualquer quantidade de lances<br>
- **Então** tais lances serão ignorados pelo leilão

#### Cenário 5
- **Dado** leilão iniciado E interessado X realizou o último lance<br>
- **Quando** mesmo interessado X realiza o próximo lance (lances consecutivos)<br>
- **Então** leilão não aceita o segundo lance

#### Cenário 6
- **Dado** leilão não iniciado<br>
- **Quando** terminam o leilão<br>
- **Então** lançar a exceção de operação inválida

#### Cenário 7
- **Dado** criar um novo lance<br>
- **Quando** é dado um lance de valor negativo<br>
- **Então** lançar a exceção de argumento inválido
<br>

### Outra forma de avaliar a melhor oferta: por valor superior mais próximo do valor de destino.<br>
Leilão tem nova modalidade de avaliação: por valor superior mais próximo. Nessa modalidade o leilão precisa de um valor de destino e a oferta que for maior e mais próxima desse valor de destino ganhará.<br>

#### Cenário 1
- **Dado** leilão iniciado com a modalidade de avaliação "valor superior mais próximo", valor de destino 1200 e lances de 800, 1150, 1400 e 1250.<br>
- **Quando** o leilão terminar<br>
- **Então** o ganhador será quem fez a oferta de 1250

#### Cenário 2
Implementado a interface IModalidadeAvaliacao para separar a responsabilidade de avaliar o ganhador do leilão para outra classe. Tirar a responsabilidade da classe Leilão (SOLID).
