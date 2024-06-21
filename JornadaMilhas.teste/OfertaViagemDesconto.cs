using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.teste
{
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaOPrecoAtualizadoQuandoAplicadoDesconto()
        {
            //arrange
            Rota rota = new Rota("OrigemA", "DestinoB");
            Periodo periodo = new Periodo(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
            double precoOriginal = 100.00;
            double desconto = 20.00;
            double precoComDesconto = precoOriginal - desconto;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
            //act
            oferta.Desconto = desconto;
            //assert
            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Theory]
        [InlineData(120,30)]
        [InlineData(100,30)]
        public void RetornarDescontoMaximoQuandoValorDescontoMaiorQueOuIgualAoPreco(double desconto, double precoComDesconto)
        {
            //arrange
            Rota rota = new Rota("OrigemA", "DestinoB");
            Periodo periodo = new Periodo(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
            double precoOriginal = 100.00;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
            //act
            oferta.Desconto = desconto;
            //assert
            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }
        [Fact]
        public void RetornarPrecoOriginalQuandoValorDescontoForNegativo()
        {
            //arrange
            Rota rota = new Rota("OrigemA", "DestinoB");
            Periodo periodo = new Periodo(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
            double precoOriginal = 100.00;
            double desconto = -10.00;
            double precoComDesconto = precoOriginal;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
            //act
            oferta.Desconto = desconto;
            //assert
            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }
    }
}
