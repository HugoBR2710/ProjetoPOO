using System;

namespace Museu
{
    // Classe Visitante derivada de Pessoa
    class Visitante : Pessoa
    {
        public string MotivoVisita { get; set; }

        public Visitante(string nome, int idade, string motivoVisita) : base(nome, idade)
        {
            Nome = nome;
            Idade = idade;
            MotivoVisita = motivoVisita;
        }


        //método para mostrar mostrar a sala onde está o visitante
        public void VisitarSala(Sala sala)
        {
            Console.WriteLine($"Sou @ {Nome} e estou a visitar {sala.Nome}");
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Olá, sou um visitante chamado {Nome}, tenho {Idade} anos e estou aqui para {MotivoVisita}.");
        }
    }
}
