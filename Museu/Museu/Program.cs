using System.Collections.Generic;
using System.Linq;
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
            var visitante = new Visitante("Maria", 25, "Conhecer o museu");
            var curador = new Curadores("Ana", 35, "Pinturas Renascentistas");
            var seguranca = new Seguranca("Carlos", 28);

            

            funcionario.Apresentar();
            visitante.Apresentar();
            curador.Inventariar();
            seguranca.ControlarAcesso();
        }
    }
}
