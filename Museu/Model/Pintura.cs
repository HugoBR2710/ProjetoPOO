using System;

namespace Museu
{

    //classe Escultura que é subclasse ou filha de Arte que é pai ou superclasse
    public class Pintura : Arte
    {
        public string Tecnica { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }

        public Pintura(string titulo, string tipoArte, int anoCriacao, string autor, string tecnica, double altura, double largura)
            : base(titulo, tipoArte, anoCriacao, autor)
        {
            Tecnica = tecnica;
            Altura = altura;
            Largura = largura;
        }
        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"Técnica: {Tecnica}\nAltura: {Altura}\nLargura: {Largura}");
        }



    }




}