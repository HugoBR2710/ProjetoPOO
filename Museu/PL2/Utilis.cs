using System;
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
    internal class Utilis
    {
        //private EsculturaBLL esculturaB;
        //private PinturaBLL pinturaB;
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
                obra.ExibirInfo();
                Console.WriteLine();
            }

        }


        //Gestão de Visitantes
        private protected void Menu5()      
        {
            Console.WriteLine("Gestão de Visitantes");
            Console.WriteLine("1 - Adicionar Visitante");
            Console.WriteLine("2 - Remover Visitante");
            Console.WriteLine("3 - Mostrar todos os visitantes do Museu e motivo");
            Console.WriteLine("6 - Sair");
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
                    case "6":
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
            Console.WriteLine("1 - Adicionar Obra de Arte à Exposição");
            Console.WriteLine("2 - Remover Obra de Arte da Exposição");
            Console.WriteLine("3 - Adicionar Visitante à Exposição");
            Console.WriteLine("4 - Remover Visitante da Exposição");
            Console.WriteLine("5 - Mostrar todas as Exposições, e Obras Expostas");
            Console.WriteLine("6 - Mostras Exposições e Visitantes");
            Console.WriteLine("9 - Sair");
        }
        public void Executar4()
        {
            bool sair = false;
            do
            {
                Menu4();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        AdicionarArteExpo();
                        break;
                    case "2":
                        Console.Clear();
                        RemoverArteExpo();
                        break;
                    case "3":
                        Console.Clear();
                        AdicionarVisitanteExpo();
                        break;
                    case "4":
                        Console.Clear();
                        RemoverVisitanteExpo();
                        break;
                    case "5":
                        Console.Clear();
                        MostrarExposicoes();
                        break;
                    case "6":
                        Console.Clear();
                        //MostrarExposicoesVisitantes();
                        break;
                    case "9":
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
        private void AdicionarArteExpo()
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

            // Adiciona a nova exposição ao DAL
            exposicaoB.AdicionarExposicao(exposicao);
            // Grava as alterações no arquivo
            exposicaoB.GravarExposicaoFic();
        }
        private void RemoverArteExpo()
        {
            Console.WriteLine("Remover Arte das Exposições");
            Console.WriteLine("Exposições Disponíveis");
            MostrarExposicoes();
            Console.WriteLine("Nome da Exposição:");
            string nome = Console.ReadLine();
            Console.WriteLine("Obras de Arte Disponíveis");
            MostrarObrasDeArte();
            Console.WriteLine("Título da Obra:");
            string titulo = Console.ReadLine();

            //Arte arte = arteB.ObterObraPorNome(titulo);
            Exposicao exposicao = exposicaoB.ObterExposicaoPorNome(nome);
            exposicao.RemoverObraExpo(titulo);
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
            Console.WriteLine("Salas Disponíveis");
            MostrarSalas();
            Console.WriteLine("Nome da Sala:");
            string nomeSala = Console.ReadLine();
            Console.WriteLine("Visitantes existentes");
            MostrarVisitantes();
            Console.WriteLine("Nome do Visitante:");
            string nome = Console.ReadLine();

            Visitante visitante = visitanteB.ObterVisitantePorNome(nome);
            Sala sala = salaB.ObterSalaPorNome(nomeSala);

            // Adicionar vistante à exposição
            Exposicao exposicao = new Exposicao(sala.Nome, sala.Capacidade);
            exposicao.AdicionarVisitanteExpo(visitante);

            // Adiciona a nova exposição ao DAL
            exposicaoB.AdicionarExposicao(exposicao);
            // Grava as alterações no arquivo
            exposicaoB.SalvarExposicaoFic();

        }
        private void RemoverVisitanteExpo()
        {
            Console.WriteLine("Remover Visitante das Exposições");
            Console.WriteLine("Exposições Disponíveis");
            MostrarExposicoes();
            Console.WriteLine("Nome da Exposição:");
            string nome = Console.ReadLine();
            Console.WriteLine("Visitantes Existentes");
            MostrarVisitantes();
            Console.WriteLine("Nome do visitante:");
            string nomeVisitante = Console.ReadLine();

            Visitante visitante = visitanteB.ObterVisitantePorNome(nomeVisitante);
            Exposicao exposicao = exposicaoB.ObterExposicaoPorNome(nome);
            exposicao.RemoverVisitanteExpo(nomeVisitante);
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
        public void MostrarExposicoes()
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
                    Console.WriteLine();
                }
            }
            
        }



    }
}
