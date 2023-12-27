using System;

namespace Museu
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Morada {get; set; }


        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }


        public Pessoa(string nome, int idade, string morada)        
        {
            Nome = nome;
            Idade = idade;
            Morada = morada;
        }





        public virtual void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
        }
    }
}
