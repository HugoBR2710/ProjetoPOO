﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization.Metadata;
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
        static SalaBLL salaB = new SalaBLL();
        static ArteBLL arteB = new ArteBLL();
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


        static void IntroduzirObra()
        {
            Console.WriteLine("Introdução de Obras de arte:\n\n");
            Console.WriteLine("que tipo de obra deseja introduzir?");
            Console.WriteLine("1. Escultura");
            Console.WriteLine("2. Pintura");
            Console.WriteLine("selecione um numero e prime enter");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    IntroduzirEscultura();
                    break;
                case "2":
                    IntroduzirPintura();
                    break;
                default:
                    Console.WriteLine("opção inválida");
                    break;
            }
        }

        static void IntroduzirEscultura()
        {
            Console.WriteLine("Introdução de Esculturas\n\n");
            
            Console.WriteLine("Título:");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ano de Criação");
            int anoCriacao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("Material");
            string material = Console.ReadLine();
            Console.WriteLine("Altura");
            double altura = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Largura");
            double largura = Convert.ToDouble(Console.ReadLine());

            Arte escultura = new Escultura(titulo, "Escultura", anoCriacao, autor, material, altura, largura);
            arteB.AdicionarObra(escultura);
        }


        static void IntroduzirPintura()
        {
            Console.WriteLine("Introdução de Pinturas\n\n");
            
            Console.WriteLine("Título:");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ano de Criação");
            int anoCriacao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("Técnica");
            string tecnica = Console.ReadLine();
            Console.WriteLine("Altura");
            double altura = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Largura");
            double largura = Convert.ToDouble(Console.ReadLine());


            Arte pintura = new Pintura(titulo, "Pintura", anoCriacao, autor, tecnica, altura, largura);
            arteB.AdicionarObra(pintura);
        }






    }
}
