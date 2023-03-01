﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
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

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("André", "ASD-1498", "preto", "Gol")]
        [InlineData("José", "POL-9242", "cinza", "Fusca")]
        [InlineData("Maria", "GDR-6524", "azul", "Opala")]
        public void ValidaFaturamentoComVariosVeiculos(
            string proprietario,
            string placa,
            string cor,
            string modelo)
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }
    }
}
