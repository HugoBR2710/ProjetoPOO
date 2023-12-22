using System;

namespace Museu
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        //public string Morada {get; set}



        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public virtual void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
        }
    }
}
