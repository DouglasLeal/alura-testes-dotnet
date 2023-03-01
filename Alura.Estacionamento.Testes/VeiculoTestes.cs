using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        //[Fact(DisplayName = "Teste nº 1")]
        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        //[Fact(DisplayName = "Teste nº 2")]
        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            var veiculo = new Veiculo();

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
            var veiculo = new Veiculo
            {
                Proprietario = "André Silva",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "ASD-9999"
            };

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }
    }
}