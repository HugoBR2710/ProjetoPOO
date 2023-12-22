using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Museu;

namespace PL
{
    internal class Utils
    {
        //private ArteBLL arteB = new ArteBLL();
        //private EsculturaBLL esculturaB;
        //private PinturaBLL pinturaB;
        private SalaBLL salaB;
        //private ExposicaoBLL exposicaoB;
        //private VisitanteBLL visitanteB;

        


        private protected void Menu1()
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Gerir Salas");
            Console.WriteLine("2 - Gerir Obras de Arte");
            Console.WriteLine("3 - Gerir Exposição");
            Console.WriteLine("4 - Gerir Visitantes");

            Console.WriteLine("6 - Sair");
        }

        private protected void Menu2()
        {
            Console.WriteLine("Gestão de Salas");
            Console.WriteLine("1 - Adicionar Sala");
            Console.WriteLine("2 - Remover Sala");
            Console.WriteLine("3 - Adicionar Arte à Sala");
            Console.WriteLine("4 - Remover Arte da Sala");
            Console.WriteLine("5 - Mostrar todas as Salas");
            Console.WriteLine("6 - Sair");
        }

        private protected void Menu3()
        {
            Console.WriteLine("Gestão de Obras de Arte");
            Console.WriteLine("1 - Adicionar Escultura");
            Console.WriteLine("2 - Remover Escultura");
            Console.WriteLine("3 - Adicionar Pintura");
            Console.WriteLine("4 - Remover Pintura");
            Console.WriteLine("5 - Mostrar todas as Obras de Arte");
            Console.WriteLine("6 - Sair");
        }

        private protected void Menu4()
        {
            Console.WriteLine("Gestão de Exposições");
            Console.WriteLine("1 - Adicionar Exposição");
            Console.WriteLine("2 - Remover Exposição");
            Console.WriteLine("3 - Adicionar Obra de Arte à Exposição");
            Console.WriteLine("4 - Remover Obra de Arte da Exposição");
            Console.WriteLine("5 - Definir Capacidade Máxima");
            Console.WriteLine("6 - Adicionar Visitante à Exposição");
            Console.WriteLine("7 - Remover Visitante da Exposição");
            //mostra todas as exposições com número de visitantes e ocupação percentual
            Console.WriteLine("8 - Mostrar todas as Exposições e número de Visitantes");
            Console.WriteLine("9 - Sair");
        }

        private protected void Menu5()      
        {
            Console.WriteLine("Gestão de Visitantes");
            Console.WriteLine("1 - Adicionar Visitante");
            Console.WriteLine("2 - Remover Visitante");
            Console.WriteLine("3 - Mostrar todos os visitantes do Museu e motivo");
            Console.WriteLine("3 - Sair");
        }

        private void AdicionarSala()
        {
            Console.WriteLine("Insira o nome da sala a adicionar");
            string nomeSala = Console.ReadLine();
            Sala salaA = new Sala(nomeSala);
            salaB.AdicionarSala(salaA);
        }

        private void RemoverSala()
        {
            Console.WriteLine("Insira o nome da sala a remover");
            string nomeSala = Console.ReadLine();
            Sala salaR = new Sala(nomeSala);
            salaB.RemoverSala(salaR);
        }

        private void AdicionarArteSala()
        {
            Console.WriteLine("Insira o nome da sala a adicionar a obra de arte");
            string nomeSala = Console.ReadLine();
            Console.WriteLine("Insira o nome da obra de arte a adicionar");
            string nomeArte = Console.ReadLine();
            Arte arteA = new Arte(nomeArte);
            Sala salaA = new Sala(nomeSala);
            salaB.AdicionarArteSala(salaA, arteA);
        }


        private void RemoverArteSala()
        {
            Console.WriteLine("Insira o nome da sala a remover a obra de arte");
            string nomeSala = Console.ReadLine();
            Console.WriteLine("Insira o nome da obra de arte a remover");
            string nomeArte = Console.ReadLine();
            Arte arteR = new Arte(nomeArte);
            Sala salaR = new Sala(nomeSala);
            salaB.RemoverArteSala(salaR, arteR);
        }


        private void MostrarTodasSalas()
        {
            salaB.MostrarTodasSalas();
        }







    }
}
