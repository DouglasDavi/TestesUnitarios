using JornadaMilhas.Modelos;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.teste
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQUandoDadosValidos()
        {
            //cenário - arrange
            Rota rota =  new Rota ("Juiz de Fora", "Rio de Janeiro");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var validacao = true;

            //ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //validação - assert
            Assert.Equal(validacao, oferta.EhValido);

        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQUandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);

        }
        [Fact]
        public void RetornaMensagemDeErroPrecoInvalidoQUandoPrecoMenorQueZero()
        {
            //arrage
            Rota rota = new Rota("Origem1", "Destino1");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = -360;

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }

        

    }
}