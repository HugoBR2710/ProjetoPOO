
using System;

namespace Museu
{
    public class Arte
    {
        public string Titulo { get; set; }
        public string TipoArte { get; set; }
        public int AnoCriacao { get; set; }
        public string Autor { get; set; }
        public Arte(string titulo, string tipoArte, int anoCriacao, string autor)
        {
            Titulo = titulo;
            TipoArte = tipoArte;
            AnoCriacao = anoCriacao;
            Autor = autor;
        }

        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Título: {Titulo}\nTipo: {TipoArte}\nAno de Criação: {AnoCriacao}\nAutor: {Autor}");
        }


    }
}