using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {

        private Veiculo _veiculo;
        public ITestOutputHelper _saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper saidaConsoleTeste)
        {
            _saidaConsoleTeste = saidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor invocado.");
            _veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParamentro10()
        {
            //Arrange
            //Act
            _veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, _veiculo.VelocidadeAtual);

        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //Act
            _veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, _veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoTipoVeiculo()
        {
            //Arrange
            //Act
            //veiculo.Tipo = null;
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, _veiculo.Tipo);

        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClassData(Veiculo modelo)
        {
            //Arrange

            //Act
            _veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, _veiculo.VelocidadeAtual);

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            _veiculo.Proprietario = "Douglas Candido";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Verde";
            _veiculo.Modelo = "Fusca";
            _veiculo.Placa = "FCQ-0000";

            //Act
            string dados = _veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dados);
        }

        public void Dispose()
        {
            _saidaConsoleTeste.WriteLine("Dispose invocado");
        }

    }
}
