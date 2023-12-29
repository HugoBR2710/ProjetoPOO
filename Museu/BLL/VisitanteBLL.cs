using DAL;
using Museu;

namespace BLL
{
    /// <summary>
    /// Representa a camada de lógica de negócios para gerir visitantes em um museu.
    /// </summary>
    public class VisitanteBLL
    {
        private VisitanteDAL visitanteDAL;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="VisitanteBLL"/>.
        /// </summary>
        public VisitanteBLL()
        {
            visitanteDAL = new VisitanteDAL();
        }

        /// <summary>
        /// Obtém todos os visitantes.
        /// </summary>
        /// <returns>Uma lista de todos os visitantes.</returns>
        public List<Visitante> ObterTodosVisitantes()
        {
            return visitanteDAL.ObterTodosVisitantes();
        }

        /// <summary>
        /// Adiciona um novo visitante à coleção.
        /// </summary>
        /// <param name="visitante">O visitante a adicionar.</param>
        public void AdicionarVisitante(Visitante visitante)
        {
            visitanteDAL.AdicionarVisitante(visitante);
        }

        /// <summary>
        /// Remove um visitante da coleção pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome do visitante a remover.</param>
        public void RemoverVisitante(string nome)
        {
            visitanteDAL.RemoverVisitante(nome);
        }

        /// <summary>
        /// Remove um visitante da coleção.
        /// </summary>
        /// <param name="visitante">O visitante a remover.</param>
        public void RemoverVisitante(Visitante visitante)
        {
            visitanteDAL.RemoverVisitante(visitante);
        }

        /// <summary>
        /// Obtém um visitante pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome do visitante.</param>
        /// <returns>O visitante com o nome especificado, ou null se não for encontrado.</returns>
        public Visitante ObterVisitantePorNome(string nome)
        {
            return visitanteDAL.ObterVisitantePorNome(nome);
        }

        /// <summary>
        /// Atualiza um visitante existente com novas informações.
        /// </summary>
        /// <param name="visitante">O visitante atualizado.</param>
        public void AtualizarVisitante(Visitante visitante)
        {
            visitanteDAL.AtualizarVisitante(visitante);
        }

        /// <summary>
        /// Guarda a lista de visitantes num ficheiro JSON.
        /// </summary>
        /// <param name="_visitantes">A lista de visitantes a guardar.</param>
        public void GravarVisitanteFic(List<Visitante> _visitantes)
        {
            visitanteDAL.GravarVisitanteFic(_visitantes);
        }

        /// <summary>
        /// Carrega a lista de visitantes a partir do ficheiro JSON.
        /// </summary>
        /// <returns>A lista de visitantes carregada.</returns>
        public List<Visitante> CarregarVisitanteFic()
        {
            return visitanteDAL.CarregarVisitanteFic();
        }
    }
}
