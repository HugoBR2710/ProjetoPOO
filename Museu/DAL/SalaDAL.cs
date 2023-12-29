using System.Text.Json;
using Museu;

namespace DAL
{
    /// <summary>
    /// Representa a camada de acesso a dados para a gestão de salas em um museu.
    /// </summary>
    public class SalaDAL
    {
        private List<Sala> _salas = new List<Sala>();
        private static string path = "sala.json";

        /// <summary>
        /// Obtém todas as salas.
        /// </summary>
        /// <returns>Lista de todas as salas.</returns>
        public List<Sala> ObterTodasSalas()
        {
            return _salas;
        }

        /// <summary>
        /// Adiciona uma nova sala à coleção.
        /// </summary>
        /// <param name="sala">A sala a ser adicionada.</param>
        public void AdicionarSala(Sala sala)
        {
            _salas.Add(sala);
        }

        /// <summary>
        /// Remove uma sala da coleção pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da sala a ser removida.</param>
        public void RemoverSala(string nome)
        {
            Sala salaParaRemover = _salas.FirstOrDefault(sala => sala.Nome == nome);

            if (salaParaRemover != null)
            {
                _salas.Remove(salaParaRemover);
                Console.WriteLine($"Sala '{nome}' removida com sucesso.");
            }
            else
            {
                Console.WriteLine($"Sala '{nome}' não encontrada.");
            }
        }

        /// <summary>
        /// Remove uma sala da coleção.
        /// </summary>
        /// <param name="sala">A sala a ser removida.</param>
        public void RemoverSala(Sala sala)
        {
            _salas.Remove(sala);
        }

        /// <summary>
        /// Obtém uma sala pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da sala.</param>
        /// <returns>A sala com o nome especificado, ou null se não for encontrada.</returns>
        public Sala ObterSalaPorNome(string nome)
        {
            return _salas.FirstOrDefault(sala => sala.Nome == nome);
        }

        /// <summary>
        /// Atualiza uma sala existente com novas informações.
        /// </summary>
        /// <param name="sala">A sala atualizada.</param>
        public void AtualizarSala(Sala sala)
        {
            var salaAtualizada = ObterSalaPorNome(sala.Nome);
            salaAtualizada.Nome = sala.Nome;
        }

        /// <summary>
        /// Grava as salas em um arquivo JSON.
        /// </summary>
        /// <param name="_salas">A lista de salas a ser gravada.</param>
        public void GravarSalaFic(List<Sala> _salas)
        {
            var json = JsonSerializer.Serialize(_salas);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Carrega as salas a partir de um arquivo JSON.
        /// </summary>
        /// <returns>A lista de salas carregada.</returns>
        public List<Sala> CarregarSalaFic()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                _salas = JsonSerializer.Deserialize<List<Sala>>(json);
                return _salas;
            }

            return new List<Sala>();
        }

        /// <summary>
        /// Salva as salas em um arquivo JSON.
        /// </summary>
        public void SalvarSalaFic()
        {
            var json = JsonSerializer.Serialize(_salas);
            File.WriteAllText(path, json);
        }
    }
}
