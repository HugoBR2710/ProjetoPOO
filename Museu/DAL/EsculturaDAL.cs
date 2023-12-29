using System.Runtime.CompilerServices;
using System.Text.Json;
using Museu;

namespace DAL
{
    /// <summary>
    /// Representa a camada de acesso a dados para a gestão de esculturas.
    /// </summary>
    public class EsculturaDAL
    {
        private List<Escultura> _escultura = new List<Escultura>();

        private const string path = "escultura.json";

        /// <summary>
        /// Obtém todas as esculturas.
        /// </summary>
        /// <returns>Lista de todas as esculturas.</returns>
        public List<Escultura> ObterTodasEsculturas()
        {
            return _escultura;
        }

        /// <summary>
        /// Adiciona uma nova escultura à coleção.
        /// </summary>
        /// <param name="escultura">A escultura a ser adicionada.</param>
        public void AdicionarEscultura(Escultura escultura)
        {
            _escultura.Add(escultura);
        }

        /// <summary>
        /// Remove uma escultura da coleção.
        /// </summary>
        /// <param name="escultura">A escultura a ser removida.</param>
        public void RemoverEscultura(Escultura escultura)
        {
            _escultura.Remove(escultura);
        }

        /// <summary>
        /// Obtém uma escultura pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da escultura.</param>
        /// <returns>A escultura com o nome especificado, ou null se não for encontrada.</returns>
        public Escultura ObterEsculturaPorNome(string nome)
        {
            return _escultura.FirstOrDefault(escultura => escultura.Titulo == nome);
        }

        /// <summary>
        /// Obtém uma escultura pelo seu nome, tipo, autor e ano de criação.
        /// </summary>
        /// <param name="nome">O nome da escultura.</param>
        /// <param name="tipo">O tipo da escultura.</param>
        /// <param name="autor">O autor da escultura.</param>
        /// <param name="ano">O ano de criação da escultura.</param>
        /// <returns>A escultura com o nome, tipo, autor e ano de criação especificados, ou null se não for encontrada.</returns>
        public Escultura ObterEsculturaPorNome(string nome, string tipo, string autor, int ano)
        {
            return _escultura.FirstOrDefault(escultura => escultura.Titulo == nome && escultura.TipoArte == tipo && escultura.Autor == autor && escultura.AnoCriacao == ano);
        }

        /// <summary>
        /// Atualiza uma escultura existente com novas informações.
        /// </summary>
        /// <param name="escultura">A escultura atualizada.</param>
        public void AtualizarEscultura(Escultura escultura)
        {
            var obra = ObterEsculturaPorNome(escultura.Titulo, escultura.TipoArte, escultura.Autor, escultura.AnoCriacao);
            obra.Titulo = escultura.Titulo;
            obra.TipoArte = escultura.TipoArte;
            obra.Autor = escultura.Autor;
            obra.AnoCriacao = escultura.AnoCriacao;
        }

        /// <summary>
        /// Salva as esculturas em um arquivo JSON.
        /// </summary>
        public void SalvarEsculturaFic()
        {
            var json = JsonSerializer.Serialize(_escultura);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Carrega as esculturas a partir de um arquivo JSON.
        /// </summary>
        public void CarregarEsculturaFic()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                _escultura = JsonSerializer.Deserialize<List<Escultura>>(json);
            }
        }
    }
}
