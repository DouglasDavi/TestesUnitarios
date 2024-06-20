using JornadaMilhas.Modelos;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.teste
{
    public class UnitTest1
    {
        [Fact]
        public void TestandoOfertaComRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);

        }
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
            Musica musica = new Musica(nome){Id = id, Artista = "KevinOChris"};
            
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
    }
}