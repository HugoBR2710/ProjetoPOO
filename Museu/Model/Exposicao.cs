﻿using System;
using System.Globalization;

namespace Museu
{

    public class Exposicao : Sala
    { 
        public int VisitantesPres  { get; set; }
        public List<Arte> ObrasDeArte { get; set; } = new List<Arte>();
        public List<Visitante> Visitantes { get; set; } = new List<Visitante>();



        //public Exposicao()
        //{

        //}

        public Exposicao(string nome, int capacidade)
        : base(nome, capacidade)
        {
            
        }

        public Exposicao(string nome, int capacidade, List<Arte>obrasDeArte)            
        : base(nome, capacidade)
        {
            ObrasDeArte = obrasDeArte;
        }

        public Exposicao(string nome, int capacidade, int visitantesPres, List<Arte> obrasDeArte, List<Visitante> visitantes)
            : base(nome, capacidade)
        {
            VisitantesPres = visitantesPres;
            ObrasDeArte = obrasDeArte;
            Visitantes = visitantes;
        }



        public void AdicionarObraExpo(Arte obra)
        {
                ObrasDeArte.Add(obra);
        }

        public void RemoverObraExpo(Arte obra)
        {
            if (ObrasDeArte.Count > 0)
            {
                ObrasDeArte.Remove(obra);
            }
            else
            {
                Console.WriteLine("Não há obras de arte para retirar.");
            }
        }


        public void AdicionarVisitante()
        {
            if (VisitantesPres < Capacidade)
            {
                VisitantesPres++;
            }
            else
            {
                Console.WriteLine("Capacidade máxima atingida. Não podem entrar mais visitantes.");
            }
        }

        public void RemoverVisitante()
        {
            if (VisitantesPres > 0)
            {
                VisitantesPres--;
            }
            else
            {
                Console.WriteLine("Não há visitantes para sair.");
            }
        }


        public static Exposicao ConverterSalaParaExposicao(Sala sala)
        {
            if (sala is Exposicao exposicao)
            {
                return exposicao;
            }
            else
            {
                return new Exposicao(sala.Nome, sala.Capacidade);
            }
        }


        //mostra o nome da Sala e obras expostas
        public void MostraSalaObras()
        {
            Console.WriteLine($"Exposição: {Nome}");
            Console.WriteLine("Obras expostas:");
            foreach (Arte obra in ObrasDeArte)
            {
                Console.WriteLine(obra.Titulo);
            }
        }





    }
    
}