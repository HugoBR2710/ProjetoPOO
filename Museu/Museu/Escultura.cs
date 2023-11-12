using System;
using System.Data;
using System.Security.AccessControl;
using Microsoft.SqlServer.Server;

namespace Museu
{

    //classe Escultura que é subclasse ou filha de Arte que é pai ou superclasse
    public class Escultura : Arte
    {
        public String Material { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }


        public Escultura(string titulo, string tipoArte, int anoCriacao, string autor, string material, double altura,
            double largura)
            : base(titulo, tipoArte, anoCriacao, autor)
        {
            Material = material;
            Altura = altura;
            Largura = largura;
        }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"Material: {Material}\nAltura: {Altura}\nLargura: {Largura}");
        }

    }

}