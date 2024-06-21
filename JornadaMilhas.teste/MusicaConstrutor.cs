﻿using JornadaMilhas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.teste
{
    public class MusicaConstrutor
    {
        [Fact]
        public void TestandoIniciaNomeMusica()
        {
            // Arrange
            string nome = "Música Teste";

            // Act
            Musica musica = new Musica(nome);

            // Assert
            Assert.Equal(nome, musica.Nome);

        }
        [Fact]
        public void TestandoIniciaIdMusica()
        {
            // Arrange
            string nome = "Música Teste";
            int id = 1;

            // Act
            Musica musica = new Musica(nome) { Id = id, Artista = "KevinOChris" };

            // Assert
            Assert.Equal(id, musica.Id);

        }
        [Fact]
        public void TestandoMetodoString()
        {
            // Arrange
            int id = 1;
            string nome = "Música Teste";
            Musica musica = new Musica(nome);
            musica.Id = id;
            string toStringEsperado = @$"Id: {id} Nome: {nome}";

            // Act
            string resultado = musica.ToString();

            // Assert
            Assert.Equal(toStringEsperado, resultado);

        }

        //Outro modelo teste
        [Fact]
        public void Jogo_CriacaoComTituloNulo_DeveLancarArgumentNullException()
        {
            // Arrange
            string tituloNulo = null;
            string capa = "CapaTeste";

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Jogo(tituloNulo, capa));
            Console.WriteLine(exception.Message);
            Assert.Equal("titulo", exception.ParamName);

            Assert.Contains("O título não pode ser nulo ou vazio.", exception.Message);
        }
    }
}