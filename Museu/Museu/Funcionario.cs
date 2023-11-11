using System;

namespace Museu
{
    class Funcionario : Pessoa
    {
        public string Cargo { get; set; }

        public Funcionario(string nome, int idade, string cargo) : base(nome, idade)
        {
            Cargo = cargo;
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Sou um funcionário chamado {Nome}, tenho {Idade} anos e sou {Cargo}.");
        }
    }
}
