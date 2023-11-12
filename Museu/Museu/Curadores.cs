using System;
using System.Collections.Generic;

namespace Museu
{
    class Curadores : Funcionario
    {
        public string AreaEspecializacao { get; set; }

        //public List<Arte> ObrasCuradas { get; set; } = new List<Arte>();

        public Curadores(string nome, int idade, string areaEspecializacao) : base (nome, idade, "Curador de Arte")
        {
            Nome = nome;
            Idade = idade;
            Cargo = "Curador de Arte";
            AreaEspecializacao = areaEspecializacao;
        }

        public void Inventariar()
        {
            Console.WriteLine($"Curador {Nome} está a efetuar o registo de obras de arte.");
        }
    }
}
