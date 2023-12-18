using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Museu
{
    public class Sala
    {
        public String Nome { get; set; }
        public List<Arte> ObrasDeArte { get; set; } = new List<Arte>();
        public Sala(string nome)
        {
            Nome = nome;
        }

        public void AdicionarObraDeArte(Arte obra)
        {
            ObrasDeArte.Add(obra);
        }

        public void RemoverObraDeArte(Arte obra)
        {
            ObrasDeArte.Remove(obra);
        }
    }
}
