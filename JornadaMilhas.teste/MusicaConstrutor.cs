using Bogus;
using JornadaMilhas.Modelos;
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
        [Fact]
        public void RetornaAnoDeLancamentoNuloQuandoValorEhMenorQueZero()
        {
            // Arrange
            int anoInvalido = -1;
            Musica musica = new Musica("Nome");

            // Act
            musica.AnoLancamento = anoInvalido;

            // Assert
            Assert.Null(musica.AnoLancamento);
        }

        [Fact]
        public void TestandoArtistaNullOuVazio()
        {
            // Arrange
            int id = 1;
            string nome = "Música Teste";
            Musica musica = new Musica(nome) { Id = id, Artista = "" };

            // Act
            string resultado = "artista desconhecido";

            // Assert
            Assert.Equal(resultado, musica.Artista);

        }
        [Fact]
        public void RetornaToStringCorretamenteQuandoMusicaEhCadastrada()
        {
            //arrange
            var faker = new Faker();
            var id = faker.Random.Int();
            var nome = faker.Lorem.Word();
            var saidaEsperada = $"Id: {id} Nome: {nome}";
            var musica = new Musica(nome) { Id = id };

            //var musicaFaker = new Faker<Musica>(nome)
            //    .RuleFor(m => m.Id, f => id++)
            //    .RuleFor(m => m.Artista, f => f.Lorem.Word())
            //    .RuleFor(m => m.AnoLancamento, f => f.Random.Number(2000, 2024));
            //act
            var result = musica.ToString();
            //assert
            Assert.Equal(saidaEsperada, result);
        }

        [Fact]
        public void RetornaArtistaDesconhecidoQuandoInseridoDadoNuloNoArtista()
        {
            // Arrange
            var nome = new Faker().Lorem.Word();
            var musica = new Musica(nome) { Artista = null };

            // Act
            var artista = musica.Artista;

            // Assert
            Assert.Equal("Artista desconhecido", artista);
        }

        [Fact]
        public void RetornoAnoDeLancamentoNuloQuandoValorInseridoMenorQueZero()
        {
            // Arrange
            var nome = new Faker().Lorem.Word();
            var musica = new Musica(nome) { AnoLancamento = -1 };

            // Act
            var anoLancamento = musica.AnoLancamento;

            // Assert
            Assert.Null(anoLancamento);
        }

        //Outro modelo teste
        [Fact]
        public void JogoCriacaoComTituloNulo_DeveLancarArgumentNullException()
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
