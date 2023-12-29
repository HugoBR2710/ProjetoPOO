using DAL;
using Museu;
/// <summary>
/// Representa a Bussiness Logic Layer (BLL) para gerir objetos da Arte.
/// </summary>
namespace BLL
{
    /// <summary>
    /// Fornece métodos para interagir com objetos da Arte através da Data Access Layer (DAL)
    /// </summary>
    public class ArteBLL
    {
        private ArteDAL arteDAL;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ArteBLL"/>.
        /// </summary>
        public ArteBLL()
        {
            arteDAL = new ArteDAL();
        }

        /// <summary>
        /// Obtém todos os objetos da Arte
        /// </summary>
        /// <returns>Uma lista de todos os objetos de Arte.</returns>
        public List<Arte> ObterTodasObrasDeArte()
        {
            return arteDAL.ObterTodasObrasDeArte();
        }

        /// <summary>
        /// Adiciona um novo objeto de Arte à coleção.
        /// </summary>
        /// <param name="arte">O objeto de Arte a adicionar.</param>
        public void AdicionarObra(Arte arte)
        {
            arteDAL.AdicionarObra(arte);
        }

        /// <summary>
        /// Remove um objeto de Arte da coleção.
        /// </summary>
        /// <param name="arte">O objeto de arte a remover.</param>
        public void RemoverObra(Arte arte)
        {
            arteDAL.RemoverObra(arte);
        }

        /// <summary>
        /// Obtém um objeto de arte pelo seu título.
        /// </summary>
        /// <param name="nome">O título do objeto de arte.</param>
        /// <returns>O objeto de arte com o título especificado, ou null se não encontrado.</returns>
        public Arte ObterObraPorNome(string nome)
        {
            return arteDAL.ObterObraPorNome(nome);
        }

        /// <summary>
        /// Obtém um objeto de arte pelo seu título, tipo, autor e ano de criação.
        /// </summary>
        /// <param name="nome">O título do objeto de arte.</param>
        /// <param name="tipo">O tipo do objeto de arte.</param>
        /// <param name="autor">O autor do objeto de arte.</param>
        /// <param name="ano">O ano de criação do objeto de arte.</param>
        /// <returns>O objeto de arte com o título, tipo, autor e ano de criação especificados, ou null se não encontrado.</returns>
        public Arte ObterObraPorNome(string nome, string tipo, string autor, int ano)
        {
            return arteDAL.ObterObraPorNome(nome, tipo, autor, ano);
        }

        /// <summary>
        /// Atualiza um objeto de arte existente com novas informações.
        /// </summary>
        /// <param name="arte">O objeto de arte atualizado.</param>
        public void AtualizarObra(Arte arte)
        {
            arteDAL.AtualizarObra(arte);
        }

        /// <summary>
        /// Guarda a lista de objetos de arte num ficheiro JSON.
        /// </summary>
        /// <param name="_obrasDeArte">A lista de objetos de arte a guardar.</param>
        public void GravarObraFic(List<Arte> _obrasDeArte)
        {
            arteDAL.GravarObraFic(_obrasDeArte);
        }

        /// <summary>
        /// Carrega a lista de objetos de arte a partir do ficheiro JSON.
        /// </summary>
        /// <returns>A lista de objetos de arte carregada.</returns>
        public List<Arte> CarregarObraFic()
        {
            return arteDAL.CarregarObraFic();
        }

        /// <summary>
        /// Remove um objeto de arte da coleção pelo seu título.
        /// </summary>
        /// <param name="nome">O título do objeto de arte a remover.</param>
        public void RemoverObra(string nome)
        {
            try
            {
                arteDAL.RemoverObra(nome);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível remover a Obra");
                throw;
            }
        }
    }
}
