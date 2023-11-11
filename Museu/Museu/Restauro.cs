using System;

namespace Museu
{
    class Restauro : Funcionario
    {
        public Restauro(string nome, int idade) : base(nome, idade, "Restaurador")
        {
            Nome = nome;
            Idade = idade;
            Cargo = "Restaurador";
        }

        public void RestaurarObras()
        {
            Console.WriteLine($"Restaurador {Nome} está a restaurar obras de arte.");
        }
    }
}
