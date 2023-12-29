using System.Text.Json;
using Museu;

namespace DAL;

public class SalaDAL
{
    private List<Sala> _salas = new List<Sala>();
    private static string path = "sala.json";

    public List<Sala> ObterTodasSalas()
    {
        return _salas; 
    }

    public void AdicionarSala(Sala sala)
    {
        _salas.Add(sala);
    }


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
    }


    public void GravarSalaFic(List<Sala> _salas)
    {
        var json = JsonSerializer.Serialize(_salas);
        File.WriteAllText(path, json);
    }

    public List<Sala> CarregarSalaFic()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            _salas = JsonSerializer.Deserialize<List<Sala>>(json);
        }
        return _salas;
    }

    public void SalvarSalaFic()
    {
        var json = JsonSerializer.Serialize(_salas);
        File.WriteAllText(path, json);
    }







}