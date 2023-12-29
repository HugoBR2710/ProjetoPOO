using System.Text.Json;
using Museu;

namespace DAL
{
    /// <summary>
    /// Representa a camada de acesso a dados para a gestão de visitantes em um museu.
    /// </summary>
    public class VisitanteDAL
    {
        private List<Visitante> _visitantes = new List<Visitante>();
        private static string path = "visitante.json";

        /// <summary>
        /// Obtém todos os visitantes.
        /// </summary>
        /// <returns>Lista de todos os visitantes.</returns>
        public List<Visitante> ObterTodosVisitantes()
        {
            return _visitantes;
        }

        /// <summary>
        /// Adiciona um novo visitante à coleção.
        /// </summary>
        /// <param name="visitante">O visitante a ser adicionado.</param>
        public void AdicionarVisitante(Visitante visitante)
        {
            _visitantes.Add(visitante);
        }

        /// <summary>
        /// Remove um visitante da coleção.
        /// </summary>
        /// <param name="visitante">O visitante a ser removido.</param>
        public void RemoverVisitante(Visitante visitante)
        {
            _visitantes.Remove(visitante);
        }

        /// <summary>
        /// Remove um visitante da coleção pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome do visitante a ser removido.</param>
        public void RemoverVisitante(string nome)
        {
            Visitante visitanteParaRemover = _visitantes.FirstOrDefault(visitante => visitante.Nome == nome);

            if (visitanteParaRemover != null)
            {
                _visitantes.Remove(visitanteParaRemover);
                Console.WriteLine($"Visitante '{nome}' removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Visitante '{nome}' não encontrado.");
            }
        }

        /// <summary>
        /// Obtém um visitante pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome do visitante.</param>
        /// <returns>O visitante com o nome especificado, ou null se não for encontrado.</returns>
        public Visitante ObterVisitantePorNome(string nome)
        {
            return _visitantes.FirstOrDefault(visitante => visitante.Nome == nome);
        }

        /// <summary>
        /// Atualiza um visitante existente com novas informações.
        /// </summary>
        /// <param name="visitante">O visitante atualizado.</param>
        public void AtualizarVisitante(Visitante visitante)
        {
            var visitanteAtualizado = ObterVisitantePorNome(visitante.Nome);
            visitanteAtualizado.Nome = visitante.Nome;
        }

        /// <summary>
        /// Grava a lista de visitantes em um arquivo JSON.
        /// </summary>
        /// <param name="_visitantes">A lista de visitantes a ser gravada.</param>
        public void GravarVisitanteFic(List<Visitante> _visitantes)
        {
            var json = JsonSerializer.Serialize(_visitantes);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Carrega a lista de visitantes a partir do arquivo JSON.
        /// </summary>
        /// <returns>A lista de visitantes carregada.</returns>
        public List<Visitante> CarregarVisitanteFic()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                _visitantes = JsonSerializer.Deserialize<List<Visitante>>(json);
            }

            return _visitantes;
        }

        /// <summary>
        /// Salva a lista de visitantes em um arquivo JSON.
        /// </summary>
        public void SalvarVisitanteFic()
        {
            var json = JsonSerializer.Serialize(_visitantes);
            File.WriteAllText(path, json);
        }
    }
}
