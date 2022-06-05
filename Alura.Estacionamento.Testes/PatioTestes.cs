﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        private Veiculo _veiculo;
        public ITestOutputHelper _saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper saidaConsoleTeste)
        {
            _saidaConsoleTeste = saidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor invocado.");
            _veiculo = new Veiculo();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            _veiculo.Proprietario = "Douglas Candido";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Verde";
            _veiculo.Modelo = "Fusca";
            _veiculo.Placa = "FCQ-0000";

            estacionamento.RegistrarEntradaVeiculo(_veiculo);
            estacionamento.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("João das Neves", "MUR-0666", "Preto", "Gol")]
        [InlineData("Brunce Wayne", "BAT-3567", "Preto", "Lincoln")]
        [InlineData("Arthur Dent", "SAP-2642", "Branca", "coração de Ouro")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            _veiculo.Proprietario = proprietario;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;
            _veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(_veiculo);
            estacionamento.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("João das Neves", "MUR-0666", "Preto", "Gol")]
        [InlineData("Brunce Wayne", "BAT-3567", "Preto", "Lincoln")]
        [InlineData("Arthur Dent", "SAP-2642", "Branca", "coração de Ouro")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();

            _veiculo.Proprietario = proprietario;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;
            _veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(_veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);

        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();

            _veiculo.Proprietario = "Douglas Candido";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Verde";
            _veiculo.Modelo = "Fusca";
            _veiculo.Placa = "FCQ-0000";

            estacionamento.RegistrarEntradaVeiculo(_veiculo);

            var veiculoAlterado = new Veiculo()
            {
                Proprietario = "Douglas Candido",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Preto",
                Modelo = "Fusca",
                Placa = "FCQ-0000"
            };

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(veiculoAlterado.Cor, alterado.Cor);
        }

        public void Dispose()
        {
            _saidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}
