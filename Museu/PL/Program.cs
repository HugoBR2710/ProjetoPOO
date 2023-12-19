using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace Museu
{
    class Program
    {


        static void Main()
        {
            // intância BLL da Arte
            ArteBLL arteBll = new ArteBLL(); 
            // Instância da BLL para Sala
            SalaBLL salaBll = new SalaBLL(); 

            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Adicionar obra de arte");
                Console.WriteLine("2 - Listar obras de arte");
                Console.WriteLine("3 - Visualizar salas e obras expostas");
                Console.WriteLine("4 - Adicionar sala");
                Console.WriteLine("5 - Remover sala");
                Console.WriteLine("6 - Remover obra de uma sala");
                Console.WriteLine("7 - Sair");
                Console.Write("Opção: ");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("\nAdicionar Obra de Arte:");
                            Console.Write("Título: ");
                            string titulo = Console.ReadLine();
                            Console.Write("Tipo: ");
                            string tipo = Console.ReadLine();
                            Console.Write("Ano de Criação: ");
                            int ano = int.Parse(Console.ReadLine());
                            Console.Write("Autor: ");
                            string autor = Console.ReadLine();

                            Arte novaObra = new Arte(titulo, tipo, ano, autor);
                            arteBll.AdicionarObra(novaObra);
                            break;

                        case 2:
                            Console.WriteLine("\nObras de Arte:");
                            var obras = arteBll.ObterTodasObrasDeArte();
                            foreach (var obra in obras)
                            {
                                Console.WriteLine($"Título: {obra.Titulo}, Tipo: {obra.TipoArte}, Autor: {obra.Autor}");
                            }
                            break;
                        
                        case 3:
                            Console.WriteLine("\nSalas e Obras Expostas:");
                            var salas = salaBll.ObterTodasSalas();
                            foreach (var sala in salas)
                            {
                                Console.WriteLine($"Sala: {sala.Nome}");
                                foreach (var obra in sala.ObrasDeArte)
                                {
                                    Console.WriteLine($"- Obra: {obra.Titulo}");
                                }
                                Console.WriteLine();
                            }

                            break;

                        case 4:
                            Console.WriteLine("\nAdicionar Sala:");
                            Console.Write("Nome da sala: ");
                            string nomeSala = Console.ReadLine();

                            Sala novaSala = new Sala(nomeSala);
                            salaBll.AdicionarSala(novaSala);
                            break;
                        case 5:
                            Console.WriteLine("\nRemover Sala:");
                            Console.Write("Nome da sala: ");
                            string nomeSalaRemover = Console.ReadLine();

                            Sala salaRemover = salaBll.ObterSalaPorNome(nomeSalaRemover);
                            if (salaRemover != null)
                            {
                                salaBll.RemoverSala(salaRemover);
                                Console.WriteLine("Sala removida com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Sala não encontrada.");
                            }
                            break;
                        case 6:
                            Console.WriteLine("\nRemover Obra de uma Sala:");
                            Console.Write("Nome da sala: ");
                            string nomeSalaRemoverObra = Console.ReadLine();

                            Sala salaRemoverObra = salaBll.ObterSalaPorNome(nomeSalaRemoverObra);
                            if (salaRemoverObra != null)
                            {
                                Console.Write("Título da obra a remover: ");
                                string tituloObra = Console.ReadLine();

                                Arte obraRemover = salaRemoverObra.ObrasDeArte.Find(o => o.Titulo == tituloObra);
                                if (obraRemover != null)
                                {
                                    Console.Write("Era suposto remover uma obra");
                                    //salaBll.RemoverObraDaSala(salaRemoverObra, obraRemover);
                                    Console.WriteLine("Obra removida da sala com sucesso.");
                                }
                                else
                                {
                                    Console.WriteLine("Obra não encontrada nesta sala.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sala não encontrada.");
                            }
                            break;
                        case 7:
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }

            Console.WriteLine("Programa terminado.");




        }
    }
}
