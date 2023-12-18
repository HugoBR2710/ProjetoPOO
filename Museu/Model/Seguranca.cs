using System;

namespace Museu
{
    class Seguranca : Funcionario
    {
        public Seguranca(string nome, int idade) : base(nome, idade, "Segurança") 
        {
            Nome = nome;
            Idade = idade;
            Cargo = "Segurança";
        }

        public void ControlarAcesso()
        {
            Console.WriteLine($"Segurança {Nome} está a controlar o acesso das áreas restritas do museu.");
        }
    }
}
