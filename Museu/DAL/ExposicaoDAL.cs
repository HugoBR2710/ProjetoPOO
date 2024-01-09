using System.Text.Json;
using Museu;

namespace DAL
{
    /// <summary>
    /// Representa a camada de acesso a dados para a gestão de exposições.
    /// </summary>
    public class ExposicaoDAL
    {
        private List<Exposicao> _exposicoes = new List<Exposicao>();

        private static string path = "exposicao.json";

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ExposicaoDAL"/>.
        /// </summary>
        public ExposicaoDAL()
        {
            _exposicoes = new List<Exposicao>();
           
        }

        /// <summary>
        /// Obtém todas as exposições.
        /// </summary>
        /// <returns>Lista de todas as exposições.</returns>
        public List<Exposicao> ObterTodasExposicoes()
        {
            return _exposicoes;
        }

        /// <summary>
        /// Adiciona uma nova exposição à coleção.
        /// </summary>
        /// <param name="exposicao">A exposição a ser adicionada.</param>
        public void AdicionarExposicao(Exposicao exposicao)
        {
            _exposicoes.Add(exposicao);
        }

        /// <summary>
        /// Remove uma exposição da coleção.
        /// </summary>
        /// <param name="exposicao">A exposição a ser removida.</param>
        public void RemoverExposicao(Exposicao exposicao)
        {
            _exposicoes.Remove(exposicao);
        }

       
        /// <summary>
        /// Obtém uma exposição pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da exposição.</param>
        /// <returns>A exposição com o nome especificado, ou null se não for encontrada.</returns>
        public Exposicao ObterExposicaoPorNome(string nome)
        {
            return _exposicoes.FirstOrDefault(exposicao => exposicao.Nome == nome);
        }


        /// <summary>
        /// Atualiza uma exposição existente com novas informações.
        /// </summary>
        /// <param name="exposicao">A exposição atualizada.</param>
        public void AtualizarExposicao(Exposicao exposicao)
        {
            var exposicaoAtualizada = ObterExposicaoPorNome(exposicao.Nome);
            exposicaoAtualizada.Nome = exposicao.Nome;
        }

        /// <summary>
        /// Grava as exposições em um arquivo JSON.
        /// </summary>
        /// <param name="_exposicoes">A lista de exposições a ser gravada.</param>
        public void GravarExposicaoFic(List<Exposicao> _exposicoes)
        {
            var json = JsonSerializer.Serialize(_exposicoes);
            File.WriteAllText(path, json);
        }

        public void SalvarExposicaoFic()
        {
            var json = JsonSerializer.Serialize(_exposicoes);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Carrega as exposições a partir de um arquivo JSON.
        /// </summary>
        /// <returns>A lista de exposições carregada.</returns>
        public List<Exposicao> CarregarExposicaoFic()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                if(json == "")
                {
                    return null;
                }
                else
                {
                    _exposicoes = JsonSerializer.Deserialize<List<Exposicao>>(json);
                    return _exposicoes;
                }
                
            }

            return new List<Exposicao>();
        }

        /// <summary>
        /// Carrega as exposições a partir de um arquivo JSON.
        /// </summary>
        /// <param name="_exposicoes">A lista de exposições a ser carregada.</param>
        public void CarregarExposicaoFic(List<Exposicao> _exposicoes)
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                _exposicoes = JsonSerializer.Deserialize<List<Exposicao>>(json);
            }
        }




        //para baixo desta linha tudo TESTE
        // não considerar
        public void AdicionarObraExpo(Arte obra, string nomeExpo)
        {
            Exposicao exposicao = ObterExposicaoPorNome(nomeExpo);
            exposicao.AdicionarObraExpo(obra);
        }



        public void AdicionarVisitanteExpo(Visitante visitante, string nomeExpo)
        {
            Exposicao exposicao = ObterExposicaoPorNome(nomeExpo);
            try
            {
                exposicao.AdicionarVisitanteExpo(visitante);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Visitante não adicionado {e.Message}" );
            }
            
        }

        public void RemoverVisitanteExpo(string nome, string nomeExpo)
        {
            Exposicao exposicao = ObterExposicaoPorNome(nomeExpo);
            exposicao.RemoverVisitanteExpo(nome);
        }

        public void RemoverObraExpo(string nome, string nomeExpo)
        {
            Exposicao exposicao = ObterExposicaoPorNome(nomeExpo);
            exposicao.RemoverObraExpo(nome);
        }



    }





}
