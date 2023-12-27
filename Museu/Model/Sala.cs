using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Museu
{
    public class Sala
    {
        public String Nome { get; set; }
        public int Capacidade { get; set; }


        public Sala()
        {

        }

        public Sala(string nome, int capacidade) 
        {
            Nome = nome;
            Capacidade = capacidade;
        }


        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Nome: {Nome}\nCapacidade: {Capacidade}");
        }


    }
}
