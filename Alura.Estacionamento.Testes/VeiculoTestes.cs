using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper consoleTeste)
        {
            veiculo = new Veiculo();
            saidaConsoleTeste = consoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado");
        }

        //[Fact(DisplayName = "Teste nº 1")]
        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        //[Fact(DisplayName = "Teste nº 2")]
        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //var veiculo = new Veiculo();

            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº 3", Skip = "Teste não implementado")]
        public void ValidaNomeDoProprietarioDoVeiculo()
        {
            
        }

        [Fact]
        public void VerificaFichaDeInformacaoDoVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();


            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";
            

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioComMedosDeTresCaracteres()
        {
            string nomeProprietario = "n";

            Assert.Throws<System.FormatException>(
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMensagemDeExecaoDoQuartoCaracterDaPlaca()
        {
            string placa = "ASDF8888";

            var ex = Assert.Throws<System.FormatException>(
                () => new Veiculo { Placa = placa }
            );

            Assert.Equal("O 4° caractere deve ser um hífen", ex.Message);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}