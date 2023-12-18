using System;

namespace Museu
{
    class Limpeza : Funcionario
    {
        public Limpeza(string nome, int idade) : base(nome, idade, "Funcionário de limpeza") 
        {
            Nome = nome;
            Idade = idade;
            Cargo = "Funcionário de Limpeza";
        }

        public void LimparSalas()
        {
            Console.WriteLine($"Funcionário da equipa de limpeza {Nome} está a limpar as salas do museu.");
        }
    }
}
