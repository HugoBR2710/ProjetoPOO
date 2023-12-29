using DAL;
using Museu;

namespace BLL;

public class ExposicaoBLL
{
    private ExposicaoDAL exposicaoDAL = new ExposicaoDAL();

    //private ExposicaoDAL exposicaoDAL;

    //public ExposicaoBLL()
    //{
    //    exposicaoDAL = new ExposicaoDAL();
    //}

    public List<Exposicao> ObterTodasExposicoes()
    {
        return exposicaoDAL.ObterTodasExposicoes();
    }

    public void AdicionarExposicao(Exposicao exposicao)
    {
        exposicaoDAL.AdicionarExposicao(exposicao);
    }

    public void RemoverExposicao(Exposicao exposicao)
    {
        exposicaoDAL.RemoverExposicao(exposicao);
    }

    public Exposicao ObterExposicaoPorNome(string nome)
    {
        return exposicaoDAL.ObterExposicaoPorNome(nome);
    }


    public void AtualizarExposicao(Exposicao exposicao)
    {
        exposicaoDAL.AtualizarExposicao(exposicao);
    }

    public void GravarExposicaoFic(List<Exposicao> _exposicoes)
    {
        exposicaoDAL.GravarExposicaoFic(_exposicoes);
    }

    public List<Exposicao> CarregarExposicaoFic()
    {
        return exposicaoDAL.CarregarExposicaoFic();
    }


    public void SalvarExposicaoFic()
    {
        exposicaoDAL.SalvarExposicaoFic();
    }




}