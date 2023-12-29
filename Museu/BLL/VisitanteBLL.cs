using DAL;
using Museu;

namespace BLL;

public class VisitanteBLL
{

    private VisitanteDAL visitanteDAL;


    public VisitanteBLL()
    {
        visitanteDAL = new VisitanteDAL();
    }

    public List<Visitante> ObterTodosVisitantes()
    {
        return visitanteDAL.ObterTodosVisitantes();
    }
    public void AdicionarVisitante(Visitante visitante)
    {
        visitanteDAL.AdicionarVisitante(visitante);
    }

    public void RemoverVisitante(string nome)
    {
        visitanteDAL.RemoverVisitante(nome);
    }

    public void RemoverVisitante(Visitante visitante)
    {
        visitanteDAL.RemoverVisitante(visitante);
    }

    public Visitante ObterVisitantePorNome(string nome)
    {
        return visitanteDAL.ObterVisitantePorNome(nome);
    }

    public void AtualizarVisitante(Visitante visitante)
    {
        visitanteDAL.AtualizarVisitante(visitante);
    }

    public void GravarVisitanteFic(List<Visitante> _visitantes)
    {
        visitanteDAL.GravarVisitanteFic(_visitantes);
    }

    public List<Visitante> CarregarVisitanteFic()
    {
        return visitanteDAL.CarregarVisitanteFic();
    }



    
}