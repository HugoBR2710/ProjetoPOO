using Museu;

namespace DAL;

public class SalaDAL
{
    private List<Sala> _salas = new List<Sala>();

    public List<Sala> ObterTodasSalas()
    {
        return _salas; 
    }

    public void AdicionarSala(Sala sala)
    {
        _salas.Add(sala);
    }

    public void RemoverSala(Sala sala)
    {
        _salas.Remove(sala);
    }

    public Sala ObterSalaPorNome(string nome)
    {
        return _salas.FirstOrDefault(sala => sala.Nome == nome);
    }

    public void AtualizarSala(Sala sala)
    {
        var salaAtualizada = ObterSalaPorNome(sala.Nome);
        salaAtualizada.Nome = sala.Nome;
        salaAtualizada.ObrasDeArte = sala.ObrasDeArte;
    }




}