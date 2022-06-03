using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo()
            {
                Proprietario = "Douglas Candido",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "FCQ-0000"
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("João das Neves", "MUR-0666", "Preto","Gol")]
        [InlineData("Brunce Wayne", "BAT-3567", "Preto","Lincoln")]
        [InlineData("Arthur Dent", "SAP-2642", "Branca","coração de Ouro")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo()
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }
    }
}
