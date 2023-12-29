using System.Text.Json;
using Museu;

namespace DAL;

public class VisitanteDAL
{
    private List<Visitante> _visitantes = new List<Visitante>();
    private static string path = "visitante.json";


    public List<Visitante> ObterTodosVisitantes()
    {
        return _visitantes; 
    }

    public void AdicionarVisitante(Visitante visitante)
    {
        _visitantes.Add(visitante);
    }

    public void RemoverVisitante(Visitante visitante)
    {
        _visitantes.Remove(visitante);
    }

    public void RemoverVisitante(string nome)
    {
        Visitante visitanteParaRemover = _visitantes.FirstOrDefault(visitante => visitante.Nome == nome);

        if (visitanteParaRemover != null)
        {
            _visitantes.Remove(visitanteParaRemover);
            Console.WriteLine($"Visitante '{nome}' removido com sucesso.");
        }
        else
        {
            Console.WriteLine($"Visitante '{nome}' não encontrado.");
        }
    }

    public Visitante ObterVisitantePorNome(string nome)
    {
        return _visitantes.FirstOrDefault(visitante => visitante.Nome == nome);
    }

    public void AtualizarVisitante(Visitante visitante)
    {
        var visitanteAtualizado = ObterVisitantePorNome(visitante.Nome);
        visitanteAtualizado.Nome = visitante.Nome; 
    }

    public void GravarVisitanteFic(List<Visitante> _visitantes)
    {
        var json = JsonSerializer.Serialize(_visitantes);
        File.WriteAllText(path, json);
    }

    public List<Visitante> CarregarVisitanteFic()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            _visitantes = JsonSerializer.Deserialize<List<Visitante>>(json);
        }
        
        return _visitantes;
    }

    public void SalvarVisitanteFic()
    {
        var json = JsonSerializer.Serialize(_visitantes);
        File.WriteAllText(path, json);
    }



}