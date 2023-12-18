using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Museu
{
    class Program
    {


        static void Main()
        {


            // Exemplo de uso
            var funcionario = new Funcionario("João", 30, "gestor");
            //var visitante = new Visitante("Maria", 25, "Conhecer o museu");
            var curador = new Curadores("Ana", 35, "Pinturas Renascentistas");
            var seguranca = new Seguranca("Carlos", 28);


            funcionario.Apresentar();
            //visitante.Apresentar();
            curador.Inventariar();
            seguranca.ControlarAcesso();

            var visitantes = new List<Visitante>();

            // Introduza os dados dos visitantes
            
            visitantes.Add(new Visitante("Maria", 25, "Conhecer a exposição de arte"));
            visitantes.Add(new Visitante("Pedro", 30, "Participar de uma palestra"));

            // Apresente os visitantes
            foreach (var visitante in visitantes)
            {
                visitante.Apresentar();
            }

            {
                // Criar obras de arte
                Escultura escultura1 = new Escultura("David", "Grega Clássica", 1501, "Michelangelo", "Mármore", 170.0, 50.0);
                Pintura pintura1 = new Pintura("Mona Lisa", "Renascimento", 1503, "Leonardo da Vinci", "Óleo sobre tela", 77.0, 53.0);
                Escultura escultura2 = new Escultura("Vitória de Samotrácia", "Helenística", -190, "Desconhecido", "Mármore", 244.0, 220.0);
                Pintura pintura2 = new Pintura("Noite Estrelada", "Pós-Impressionismo", 1889, "Vincent van Gogh", "Óleo sobre tela", 73.7, 92.1);

                // Criar salas
                Sala salaEsculturas = new Sala("Sala de Esculturas");
                Exposicao salaExposicaoPinturas = new Exposicao("Sala de Pinturas", 10);

                // Adicionar obras às salas
                salaEsculturas.AdicionarObraDeArte(escultura1);
                salaEsculturas.AdicionarObraDeArte(escultura2);
                salaExposicaoPinturas.AdicionarObraDeArte(pintura1);
                salaExposicaoPinturas.AdicionarObraDeArte(pintura2);

                // Exibir informações sobre as obras e as salas
                ExibirInformacoesObra(escultura1);
                ExibirInformacoesObra(pintura1);
                ExibirInformacoesObra(escultura2);
                ExibirInformacoesObra(pintura2);

                Console.WriteLine("\nSalas:");
                ExibirObrasNaSala(salaEsculturas);
                ExibirObrasNaSala(salaExposicaoPinturas);

                Console.ReadLine(); // Aguarda a entrada do usuário antes de fechar a aplicação
            }

            static void ExibirInformacoesObra(Arte obra)
            {
                Console.WriteLine("Informações sobre a obra:");
                obra.ExibirInfo();
                Console.WriteLine();
            }

            static void ExibirObrasNaSala(Sala sala)
            {
                Console.WriteLine($"Sala: {sala.Nome}");
                foreach (var obra in sala.ObrasDeArte)
                {
                    ExibirInformacoesObra(obra);
                }
                Console.WriteLine();
            }




        }
    }
}
