using System.Text.Json;
using Museu;
using static System.String;

namespace DAL
{
    /// <summary>
    /// Representa a camada de acesso a dados para a gestão de obras de arte.
    /// </summary>
    public class ArteDAL
    {
        private const string path = "arte.json";

        private List<Arte> _obrasDeArte = new List<Arte>();

        /// <summary>
        /// Obtém todas as obras de arte.
        /// </summary>
        /// <returns>Lista de todas as obras de arte.</returns>
        public List<Arte> ObterTodasObrasDeArte()
        {
            return _obrasDeArte;
        }

        /// <summary>
        /// Adiciona uma nova obra de arte à coleção.
        /// </summary>
        /// <param name="obraDeArte">A obra de arte a ser adicionada.</param>
        public void AdicionarObra(Arte obraDeArte)
        {
            _obrasDeArte.Add(obraDeArte);
        }

        /// <summary>
        /// Remove uma obra de arte da coleção.
        /// </summary>
        /// <param name="obraDeArte">A obra de arte a ser removida.</param>
        public void RemoverObra(Arte obraDeArte)
        {
            _obrasDeArte.Remove(obraDeArte);
        }

        /// <summary>
        /// Obtém uma obra de arte pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da obra de arte.</param>
        /// <returns>A obra de arte com o nome especificado, ou null se não for encontrada.</returns>
        public Arte ObterObraPorNome(string nome)
        {
            return _obrasDeArte.FirstOrDefault(obra => obra.Titulo == nome);
        }


        /// <summary>
        /// Obtém uma obra de arte pelo seu nome, tipo, autor e ano de criação.
        /// </summary>
        /// <param name="nome">O nome da obra de arte.</param>
        /// <param name="tipo">O tipo da obra de arte.</param>
        /// <param name="autor">O autor da obra de arte.</param>
        /// <param name="ano">O ano de criação da obra de arte.</param>
        /// <returns>A obra de arte com o nome, tipo, autor e ano de criação especificados, ou null se não for encontrada.</returns>
        public Arte ObterObraPorNome(string nome, string tipo, string autor, int ano)
        {
            return _obrasDeArte.FirstOrDefault(obra => obra.Titulo == nome && obra.TipoArte == tipo && obra.Autor == autor && obra.AnoCriacao == ano);
        }

        /// <summary>
        /// Atualiza uma obra de arte existente com novas informações.
        /// </summary>
        /// <param name="obraDeArte">A obra de arte atualizada.</param>
        public void AtualizarObra(Arte obraDeArte)
        {
            var obra = ObterObraPorNome(obraDeArte.Titulo, obraDeArte.TipoArte, obraDeArte.Autor, obraDeArte.AnoCriacao);
            obra.Titulo = obraDeArte.Titulo;
            obra.TipoArte = obraDeArte.TipoArte;
            obra.Autor = obraDeArte.Autor;
            obra.AnoCriacao = obraDeArte.AnoCriacao;
        }

        /// <summary>
        /// Grava as obras de arte em um arquivo JSON.
        /// </summary>
        /// <param name="_obrasDeArte">A lista de obras de arte a ser gravada.</param>
        public void GravarObraFic(List<Arte> _obrasDeArte)
        {
            var json = JsonSerializer.Serialize(_obrasDeArte);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Carrega as obras de arte a partir de um arquivo JSON.
        /// </summary>
        /// <returns>A lista de obras de arte carregada.</returns>
        public List<Arte> CarregarObraFic()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                _obrasDeArte = JsonSerializer.Deserialize<List<Arte>>(json);
                return _obrasDeArte;
            }

            return new List<Arte>();
        }

        /// <summary>
        /// Remove uma obra de arte da coleção pelo seu título.
        /// </summary>
        /// <param name="titObra">O título da obra de arte a ser removida.</param>
        public void RemoverObra(string titObra)
        {
            List<Arte> obraArt = CarregarObraFic();
            Arte obraARemover = obraArt.FirstOrDefault(obra => obra.Titulo == titObra);

            if (obraARemover != null)
            {
                obraArt.Remove(obraARemover);
                GravarObraFic(obraArt);
                Console.WriteLine($"A obra '{titObra}' foi removida do acervo");
            }
            else
            {
                Console.WriteLine($"A obra '{titObra}' não foi encontrada no acervo");
            }
        }
    }
}
