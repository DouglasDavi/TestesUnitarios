using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Modelos
{
    public class Musica
    {
        private int? anoLancamento;
        private string artista;

        public Musica(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public int Id { get; set; }

        public int? AnoLancamento
        {
            get => anoLancamento;
            set
            {
                if (value <= 0) 
                {
                    anoLancamento = null;
                }
                else
                {
                    anoLancamento = value;
                }
            }
        }
        public string Artista { get => artista; set { if (value.IsNullOrEmpty()) { artista = "artista desconhecido"; } else { artista = value; } } }

        public void ExibirFichaTecnica()
        {
            Console.WriteLine($"Nome: {Nome}");

        }

        public override string ToString()
        {
            return @$"Id: {Id} Nome: {Nome}";
        }
    }

    public class Jogo 
    {
        public string Titulo { get; }
        public string Capa { get; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int Id { get; set; }

        private readonly List<int> listaNotas = new List<int>();

        public double Media => listaNotas.Count > 0 ? listaNotas.Average() : 0;

        public Jogo(string titulo, string capa)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentNullException(nameof(titulo), "O título não pode ser nulo ou vazio.");
            }

            Titulo = titulo;
            Capa = capa;
        }

        public Jogo(string titulo, string capa, double preco, string descricao, int id = 0)
            : this(titulo, capa)
        {
            Preco = preco;
            Descricao = descricao;
            Id = id;
        }

        public void Recomendar(int nota)
        {
            listaNotas.Add(nota);
        }
    }

}
