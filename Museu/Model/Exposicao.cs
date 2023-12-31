using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Museu
{

    public class Exposicao : Sala
    { 
        public int VisitantesPres  { get; set; }

        public List<Arte> ObrasDeArte { get; set; } = new List<Arte>();
        public List<Visitante> Visitantes { get; set; } = new List<Visitante>();


        public Exposicao(string nome, int capacidade) : base(nome, capacidade)
        {

        }

        //O que foi adicionado foi isto devido ao erro de parametros
        public Exposicao() : base("",0)
        {

        }

        public Exposicao(string nome, int capacidade, List<Arte>obrasDeArte) : base(nome, capacidade)
        {
            ObrasDeArte = obrasDeArte;
        }

        [JsonConstructor]
        public Exposicao(string nome, int capacidade, int visitantesPres, List<Arte> obrasDeArte, List<Visitante> visitantes) : base(nome, capacidade)
        {
            VisitantesPres = visitantesPres;
            ObrasDeArte = obrasDeArte;
            Visitantes = visitantes;
        }



        public void AdicionarObraExpo(Arte obra)
        {
                ObrasDeArte.Add(obra);
        }

        public void AdicionarVisitanteExpo(Visitante visitante)
        {
            Visitantes.Add(visitante);
        }

        public void RemoverVisitanteExpo(string nome)
        {
            Visitante visitante = Visitantes.FirstOrDefault(visitante => visitante.Nome == nome);

            if (Visitantes != null)
            {
                Visitantes.Remove(visitante);
                Console.WriteLine($"Visitante {nome} Removido com sucesso");
            }
            else
            {
                Console.WriteLine($"Não foi possível remover o visitante {nome} da exposição");
            }
        }


        public void RemoverObraExpo(string nome)
        {
            Arte ObraParaRemover = ObrasDeArte.FirstOrDefault(obra => obra.Titulo == nome);

            if (ObraParaRemover != null)
            {
                ObrasDeArte.Remove(ObraParaRemover);

                Console.WriteLine($"Removido com sucesso");
            }
            else
            {
                Console.WriteLine($"Não foi possível remover a obra da exposição");
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

        public void MostraExpoVis()
        {
            //Console.WriteLine($"Exposição: {Nome}");
            Console.WriteLine("Visitantes:");
            foreach (Visitante visitante in Visitantes)
            {
                Console.WriteLine(visitante.Nome);
            }
            
        }

        public void MostraNome()
        {
            Console.WriteLine($"Exposição: {Nome}");
        }






    }
    
}