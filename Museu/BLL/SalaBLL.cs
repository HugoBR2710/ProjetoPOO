using DAL;
using Museu;

namespace BLL
{
    /// <summary>
    /// Representa a camada de lógica de negócios para gerir salas em um museu.
    /// </summary>
    public class SalaBLL
    {
        private SalaDAL salaDAL;

        private static string path = "sala.json";

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="SalaBLL"/>.
        /// </summary>
        public SalaBLL()
        {
            salaDAL = new SalaDAL();
        }

        /// <summary>
        /// Obtém todas as salas.
        /// </summary>
        /// <returns>Uma lista de todas as salas.</returns>
        public List<Sala> ObterTodasSalas()
        {
            return salaDAL.ObterTodasSalas();
        }

        /// <summary>
        /// Adiciona uma nova sala à coleção.
        /// </summary>
        /// <param name="sala">A sala a adicionar.</param>
        public void AdicionarSala(Sala sala)
        {
            salaDAL.AdicionarSala(sala);
        }

        /// <summary>
        /// Remove uma sala da coleção pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da sala a remover.</param>
        public void RemoverSala(string nome)
        {
            salaDAL.RemoverSala(nome);
        }

        /// <summary>
        /// Remove uma sala da coleção.
        /// </summary>
        /// <param name="sala">A sala a remover.</param>
        public void RemoverSala(Sala sala)
        {
            salaDAL.RemoverSala(sala);
        }

        /// <summary>
        /// Obtém uma sala pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da sala.</param>
        /// <returns>A sala com o nome especificado, ou null se não for encontrada.</returns>
        public Sala ObterSalaPorNome(string nome)
        {
            return salaDAL.ObterSalaPorNome(nome);
        }

        /// <summary>
        /// Atualiza uma sala existente com novas informações.
        /// </summary>
        /// <param name="sala">A sala atualizada.</param>
        public void AtualizarSala(Sala sala)
        {
            salaDAL.AtualizarSala(sala);
        }

        /// <summary>
        /// Guarda a lista de salas num ficheiro JSON.
        /// </summary>
        /// <param name="_salas">A lista de salas a guardar.</param>
        public void GravarSalaFic(List<Sala> _salas)
        {
            salaDAL.GravarSalaFic(_salas);
        }

        /// <summary>
        /// Carrega a lista de salas a partir do ficheiro JSON.
        /// </summary>
        /// <returns>A lista de salas carregada.</returns>
        public List<Sala> CarregarSalaFic()
        {
            return salaDAL.CarregarSalaFic();
        }
    }
}
