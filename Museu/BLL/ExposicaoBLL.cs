﻿using DAL;
using Museu;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
/// <summary>
/// Representa a camada de lógica de negócios para gerir exposições.
/// </summary>
namespace BLL
{
    /// <summary>
    /// Fornece métodos para interagir com exposições através da camada de acesso a dados.
    /// </summary>
    public class ExposicaoBLL
    {
        private ExposicaoDAL exposicaoDAL = new ExposicaoDAL();

        /// <summary>
        /// Obtém todas as exposições.
        /// </summary>
        /// <returns>Uma lista de todas as exposições.</returns>
        public List<Exposicao> ObterTodasExposicoes()
        {
            return exposicaoDAL.ObterTodasExposicoes();
        }

        /// <summary>
        /// Adiciona uma nova exposição à coleção.
        /// </summary>
        /// <param name="exposicao">A exposição a adicionar.</param>
        public void AdicionarExposicao(Exposicao exposicao)
        {
            exposicaoDAL.AdicionarExposicao(exposicao);
        }

        /// <summary>
        /// Remove uma exposição da coleção.
        /// </summary>
        /// <param name="exposicao">A exposição a remover.</param>
        public void RemoverExposicao(Exposicao exposicao)
        {
            exposicaoDAL.RemoverExposicao(exposicao);
        }

        /// <summary>
        /// Obtém uma exposição pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da exposição.</param>
        /// <returns>A exposição com o nome especificado, ou null se não for encontrada.</returns>
        public Exposicao ObterExposicaoPorNome(string nome)
        {
            return exposicaoDAL.ObterExposicaoPorNome(nome);
        }

        /// <summary>
        /// Atualiza uma exposição existente com novas informações.
        /// </summary>
        /// <param name="exposicao">A exposição atualizada.</param>
        public void AtualizarExposicao(Exposicao exposicao)
        {
            exposicaoDAL.AtualizarExposicao(exposicao);
        }

        /// <summary>
        /// Guarda a lista de exposições num ficheiro.
        /// </summary>
        /// <param name="_exposicoes">A lista de exposições a guardar.</param>
        public void GravarExposicaoFic(List<Exposicao> _exposicoes)
        {
            exposicaoDAL.GravarExposicaoFic(_exposicoes);
        }

        public void SalvarExposicaoFic()
        {
            exposicaoDAL.SalvarExposicaoFic();
        }
        /// <summary>
        /// Carrega a lista de exposições a partir do ficheiro.
        /// </summary>
        /// <returns>A lista de exposições carregada.</returns>
        public List<Exposicao> CarregarExposicaoFic()
        {
            return exposicaoDAL.CarregarExposicaoFic();
        }

        //Teste abaixo desta linha 
        //tudo testes não considerar pf
        public void AdicionarObraExpo(Arte obra, string nomeExpo)
        {
            exposicaoDAL.AdicionarObraExpo(obra, nomeExpo);
        }

        public void AdicionarVisitanteExpo(Visitante visitante, string nomeExpo)
        {
            exposicaoDAL.AdicionarVisitanteExpo(visitante, nomeExpo);
        }

        public void RemoverVisitanteExpo(string nomeVisitante, string nomeExpo)
        {
            exposicaoDAL.RemoverVisitanteExpo(nomeVisitante, nomeExpo);
        }

        public void RemoverObraExpo(string nomeObra, string nomeExpo)
        {
            exposicaoDAL.RemoverObraExpo(nomeObra, nomeExpo);
        }




    }
}
