using DAL;
using Museu;

namespace BLL;

public class SalaBLL
{
    private SalaDAL salaDAL;

    private static string path = "sala.json";


    public SalaBLL()
    {
        salaDAL = new SalaDAL();
    }


    public List<Sala> ObterTodasSalas()
    {
        return salaDAL.ObterTodasSalas();
    }

    public void AdicionarSala(Sala sala)
    {
        salaDAL.AdicionarSala(sala);
    }

    public void RemoverSala(String nome)
    {
        salaDAL.RemoverSala(nome);
    }


    public void RemoverSala(Sala sala)
    {
        salaDAL.RemoverSala(sala);
    }

    public Sala ObterSalaPorNome(string nome)
    {
        return salaDAL.ObterSalaPorNome(nome);
    }

    public void AtualizarSala(Sala sala)
    {
        salaDAL.AtualizarSala(sala);
    }


    public void GravarSalaFic(List<Sala> _salas)
    {
        salaDAL.GravarSalaFic(_salas);
    }


    public List<Sala> CarregarSalaFic()
    {
        return salaDAL.CarregarSalaFic();
    }



}