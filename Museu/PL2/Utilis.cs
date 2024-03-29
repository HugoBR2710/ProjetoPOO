﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using BLL;
using Museu;

namespace PL
{
    internal class Utilis
    {
        static SalaBLL salaB = new SalaBLL();
        static ArteBLL arteB = new ArteBLL();
        private ExposicaoBLL exposicaoB = new ExposicaoBLL();
        private VisitanteBLL visitanteB = new VisitanteBLL();

        

        //Menu Inicial
        private protected void Menu1()
        {
            Console.Clear();
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Gerir Salas");
            Console.WriteLine("2 - Gerir Obras de Arte");
            Console.WriteLine("3 - Gerir Exposição");
            Console.WriteLine("4 - Gerir Visitantes");
            Console.WriteLine("5 - Sair");
        }
        public void Executar1()
        {
            bool sair = false;
            do
            {
                Menu1();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Executar2();
                        break;
                    case "2":
                        Executar3();
                        break;
                    case "3":
                        Executar4();
                        break;
                    case "4":
                        Executar5();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }


        //Gestão de Salas
        private protected void Menu2()
        {
            Console.WriteLine("Gestão de Salas");
            Console.WriteLine("1 - Adicionar Sala");
            Console.WriteLine("2 - Remover Sala");
            Console.WriteLine("3 - Mostrar todas as Salas");
            Console.WriteLine("4 - Sair");
        }
        public void Executar2()
        {
            bool sair = false;
            Console.Clear();
            Menu2();
            do
            {
                
                
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        AdicionarSala();
                        Menu2();
                        break;
                    case "2":
                        Console.Clear();
                        RemoverSala();
                        Menu2();
                        break;
                    case "3":
                        Console.Clear();
                        MostrarSalas();
                        Menu2();
                        break;
                    case "4":
                        sair = true;
                        Menu1();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private void AdicionarSala()
        {
            Console.WriteLine("Introdução de Salas\n\n");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Capacidade:");
            int capacidade = Convert.ToInt32(Console.ReadLine());
           

            Sala sala = new Sala(nome, capacidade);
            salaB.AdicionarSala(sala);
            salaB.GravarSalaFic(salaB.ObterTodasSalas());
        }
        private void RemoverSala()
        {
            Console.WriteLine("Remover Sala\n\n");
            Console.WriteLine("Salas Disponíveis");
            MostrarSalas();
            Console.WriteLine("Nome da Sala a Remover:");
            string nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome)) 
            {
                salaB.RemoverSala(nome);
            }
            else
            {
                Console.WriteLine("Nome inválido. Tente novamente.");
            }

        }
        private void MostrarSalas()
        {
            Console.WriteLine("\nSalas disponíveis:");
            var salas = salaB.CarregarSalaFic();

            foreach (Sala sala in salas)
            {
                sala.ExibirInfo();
                Console.WriteLine();
            }
        }


        //Gestão de obras de arte
        private protected void Menu3()
        {
            Console.WriteLine("Gestão de Obras de Arte\n\n");
            Console.WriteLine("1 - Adicionar Obra de Arte");
            Console.WriteLine("2 - Remover Obra de Arte");
            Console.WriteLine("3 - Mostrar todas as Obras de Arte");
            Console.WriteLine("4 - Sair");
        }
        public void Executar3()
        {
            bool sair = false;
            Console.Clear();
            Menu3();
            do
            {
                
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        IntroduzirObra();
                        Menu3();
                        break;
                    case "2":
                        Console.Clear();
                        RemoverObra();
                        Menu3();
                        break;
                    case "3":
                        Console.Clear();
                        MostrarObrasDeArte();
                        Menu3();
                        break;
                    case "4":
                        Console.Clear();
                        sair = true;
                        Menu1();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        static void IntroduzirObra()
        {
            Console.WriteLine("Introdução de Obras de arte:\n\n");
            Console.WriteLine("que tipo de obra deseja introduzir?");
            Console.WriteLine("1. Escultura");
            Console.WriteLine("2. Pintura");
            Console.WriteLine("selecione um número e prime enter");

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

            arteB.GravarObraFic(arteB.ObterTodasObrasDeArte());
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

            arteB.GravarObraFic(arteB.ObterTodasObrasDeArte());
        }
        static void RemoverObra()
        {
            Console.WriteLine("Remover Obra de Arte\n\n");
            Console.WriteLine("Obras Disponíveis");
            MostrarObrasDeArte();
            Console.WriteLine("Título da Obra a Remover:");
            string titulo = Console.ReadLine();
            try
            {
                arteB.RemoverObra(titulo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Obra Inválida ");
                throw;
            }

        }
        static void MostrarObrasDeArte()
        {
            Console.WriteLine("\nObras de Arte disponíveis:");

            var obras = arteB.CarregarObraFic();

            foreach (Arte obra in obras)
            {
                try
                {
                    obra.ExibirInfo();
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não tem obras disponiveis para mostrar");
                    Console.WriteLine(e.Message);
                    throw;
                }
               
            }

        }


        //Gestão de Visitantes
        private protected void Menu5()      
        {
            Console.WriteLine("Gestão de Visitantes");
            Console.WriteLine("1 - Adicionar Visitante");
            Console.WriteLine("2 - Remover Visitante");
            Console.WriteLine("3 - Mostrar todos os visitantes do Museu e motivo");
            Console.WriteLine("4 - Sair");
        }
        public void Executar5()
        {
            bool sair = false;
            Console.Clear();
            Menu5();
            do
            {
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        AdicionarVisitantes();
                        Menu5();
                        break;
                    case "2":
                        Console.Clear();
                        RemoverVisitantes();
                        Menu5();
                        break;
                    case "3":
                        Console.Clear();
                        MostrarVisitantes();
                        Menu5();
                        break;
                    case "4":
                        sair = true;
                        Menu1();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private void AdicionarVisitantes()
        {
            Console.WriteLine("Introdução de um Visitante\n\n");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Idade:");
            int idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Motivo Da Visita:");
            string motivoVisita = Console.ReadLine();


            Visitante visitante = new Visitante(nome, idade, motivoVisita);
            visitanteB.AdicionarVisitante(visitante);
            visitanteB.GravarVisitanteFic(visitanteB.ObterTodosVisitantes());
        }
        private void RemoverVisitantes()
        {
            Console.WriteLine("Remover Visitante\n\n");
            Console.WriteLine("Visitantes existentes");
            MostrarVisitantes();
            Console.WriteLine("Nome do Visitante a Remover:");
            string nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome))
            {
                visitanteB.RemoverVisitante(nome);
                Console.WriteLine($"Visitante {nome} saiu do Museu");
                visitanteB.GravarVisitanteFic(visitanteB.ObterTodosVisitantes());
            }
            else
            {
                Console.WriteLine("Nome inválido. Tente novamente.");
            }

        }
        private void MostrarVisitantes()
        {
            Console.WriteLine("\nVisitantes:");
            var visitantes = visitanteB.CarregarVisitanteFic();

            foreach (Visitante visitante in visitantes)
            {
                visitante.Apresentar();
                Console.WriteLine();
            }
        }

        //Gestão de exposições
        private protected void Menu4()
        {
            Console.WriteLine("Gestão de Exposições");
            Console.WriteLine("1 - Adicionar Obra de Arte à Sala");
            Console.WriteLine("2 - Adicionar Obra de Arte à Exposição");
            Console.WriteLine("3 - Remover Obra de Arte da Exposição");
            Console.WriteLine("4 - Adicionar Visitante à Exposição");
            Console.WriteLine("5 - Remover Visitante da Exposição");
            Console.WriteLine("6 - Mostrar todas as Exposições, e Obras Expostas");
            Console.WriteLine("7 - Mostras Exposições e Visitantes");
            Console.WriteLine("8 - Sair");
        }
        public void Executar4()
        {
            bool sair = false;
            Console.Clear();
            Menu4();
            do
            {
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        AdicionarArteSala();
                        Menu4();
                        break;
                    case "2":
                        Console.Clear();
                        AdicionarArteExpo();
                        Menu4();
                        break;
                    case "3":
                        Console.Clear();
                        RemoverArteExpo();
                        Menu4();
                        break;
                    case "4":
                        Console.Clear();
                        AdicionarVisitanteExpo();
                        Menu4();
                        break;
                    case "5":
                        Console.Clear();
                        RemoverVisitanteExpo();
                        Menu4();
                        break;
                    case "6":
                        Console.Clear();
                        MostrarExposicoesObras();
                        Menu4();
                        break;
                    case "7":
                        Console.Clear();
                        MostrarExposicoesVisitantes();
                        Menu4();
                        break;
                    case "8":
                        Console.Clear();
                        sair = true;
                        Menu1();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private void AdicionarArteSala()
        {
            exposicaoB.ObterTodasExposicoes();
            Console.WriteLine("Adicionar Arte à Sala\n\n");
            Console.WriteLine("Salas Disponíveis");
            MostrarSalas();
            Console.WriteLine("Nome da Sala:");
            string nome = Console.ReadLine();
            Console.WriteLine("Obras de Arte Disponíveis");
            MostrarObrasDeArte();
            Console.WriteLine("Título da Obra:");
            string titulo = Console.ReadLine();

            Arte arte = arteB.ObterObraPorNome(titulo);
            Sala sala = salaB.ObterSalaPorNome(nome);

            // Cria a nova exposição
            Exposicao exposicao = new Exposicao(sala.Nome, sala.Capacidade);
            exposicao.AdicionarObraExpo(arte);
            // Eimina a sala e a obra da lista
            salaB.RemoverSala(nome);
            arteB.RemoverObra(titulo);
            // Adiciona a nova exposição ao DAL
            exposicaoB.AdicionarExposicao(exposicao);
            // Grava as alterações no arquivo
            exposicaoB.SalvarExposicaoFic();
            salaB.GravarSalaFic(salaB.ObterTodasSalas());
        }

        private void AdicionarArteExpo()
        {
            Console.WriteLine("Adicionar Arte à Exposição\n\n");
            Console.WriteLine("Exposições Disponíveis");
            MostrarExposicoesObras();
            Console.WriteLine("Nome da Exposição:");
            string nome = Console.ReadLine();
            Console.WriteLine("Obras de Arte Disponíveis");
            MostrarObrasDeArte();
            Console.WriteLine("Título da Obra:");
            string titulo = Console.ReadLine();

            Arte arte = arteB.ObterObraPorNome(titulo);
            //Adiciona a nova exposição ao BLL
            exposicaoB.AdicionarObraExpo(arte, nome);
            arteB.RemoverObra(titulo);

            // Grava as alterações no arquivo
            exposicaoB.SalvarExposicaoFic();
            arteB.GravarObraFic(arteB.ObterTodasObrasDeArte());
        }

        private void RemoverArteExpo()
        {
            Console.WriteLine("Remover Arte das Exposições");
            Console.WriteLine("Exposições Disponíveis");
            MostrarExposicoesObras();
            Console.WriteLine("Nome da Exposição:");
            string nome = Console.ReadLine();
            Console.WriteLine("Obras de Arte Existentes");
            Exposicao exposicao = exposicaoB.ObterExposicaoPorNome(nome);

            MostrarArteExposicao(exposicao);
            Console.WriteLine("Título da Obra a remover:");
            string titulo = Console.ReadLine();

            exposicaoB.RemoverObraExpo(titulo, nome);
            arteB.GravarObraFic(arteB.ObterTodasObrasDeArte());

            try
            {
                exposicaoB.GravarExposicaoFic(exposicaoB.ObterTodasExposicoes());
                Console.WriteLine("Obra removida com sucesso e exposição atualizada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar gravar a exposição no arquivo.");
                Console.WriteLine(ex.Message);
            }

        }



        private void AdicionarVisitanteExpo()
        {
            Console.WriteLine("Adicionar Visitante à Sala\n\n");
            Console.WriteLine("Exposições Disponíveis");
            MostrarExposicoes();
            Console.WriteLine("Nome da Exposição:");
            string exposicao = Console.ReadLine();
            Console.WriteLine("Visitantes existentes");
            MostrarVisitantes();
            Console.WriteLine("Nome do Visitante a adicionar:");
            string nomeVis = Console.ReadLine();

            exposicaoB.AdicionarVisitanteExpo(visitanteB.ObterVisitantePorNome(nomeVis), exposicao);
            //remove o visitante da lista
            if (exposicaoB.ObterExposicaoPorNome(exposicao).Visitantes.Count == exposicaoB.ObterExposicaoPorNome(exposicao).Capacidade)
            {
                Console.WriteLine("Procure outra Exposição para visitar");
            }
            else
            {
                visitanteB.RemoverVisitante(nomeVis);
                Console.WriteLine($"Visitante '{nomeVis}' entrou na Exposição");
            }
           // Grava as alterações no arquivo
            exposicaoB.SalvarExposicaoFic();
            visitanteB.GravarVisitanteFic(visitanteB.ObterTodosVisitantes());
        }

        private void RemoverVisitanteExpo()
        {
            Console.WriteLine("Remover Visitante das Exposições");
            Console.WriteLine("Exposições e Respectiva Ocupação");
            MostrarExposicoesVisitantes();
            Console.WriteLine("Nome da Exposição:");
            string nome = Console.ReadLine();
            Console.WriteLine("Nome do visitante a remover:");
            string nomeVisitante = Console.ReadLine();

            exposicaoB.RemoverVisitanteExpo(nomeVisitante, nome);
            try
            {
                exposicaoB.GravarExposicaoFic(exposicaoB.ObterTodasExposicoes());
                Console.WriteLine("Visitante removido com sucesso e exposição atualizada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar gravar a exposição no arquivo.");
                Console.WriteLine(ex.Message);
            }
        }

        public void MostrarExposicoesObras()
        {
            var exposicoes = exposicaoB.CarregarExposicaoFic();
            if(exposicoes == null)
            {
                Console.WriteLine("Não há exposições disponíveis");

            }
            else
            {
                Console.WriteLine("\nExposições disponíveis:");


                foreach (Exposicao exposicao in exposicoes)
                {
                    exposicao.MostraSalaObras();
                    Console.WriteLine("\n");
                }
            }
            
        }

        public void MostrarExposicoes()
        {
            var exposicoes = exposicaoB.CarregarExposicaoFic();
            foreach (Exposicao exposicao in exposicoes)
            {
                exposicao.MostraNome();
                Console.WriteLine("\n");
            }
        }


        public void MostrarExposicoesVisitantes()
        {
            var exposicoes = exposicaoB.CarregarExposicaoFic();
            if (exposicoes == null)
            {
                Console.WriteLine("Não há exposições disponíveis\n");

            }
            else
            {
                Console.WriteLine("\nExposições disponíveis: \n");


                foreach (Exposicao exposicao in exposicoes)
                {
                    exposicao.MostraExpoVis() ;
                    Console.WriteLine();
                }

                
            }
        }





        public void MostrarArteExposicao(Exposicao exposicao)
        {
            Console.WriteLine("\nObras de Arte disponíveis:");

            foreach (Arte obra in exposicao.ObrasDeArte)
            {
                obra.ExibirInfo();
                Console.WriteLine();
            }
        }
    }
}
