using System;

namespace Museu
{

    public class Exposicao : Sala
    { 
        public int Capacidade { get; set; }
        public int VisitantesPres  { get; set; }


        public Exposicao(string nome, int capacidadeM) : base(nome)
        {
            Capacidade = capacidadeM;
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




    }
    
}