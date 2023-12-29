using System.Text.Json;
using Museu;

namespace DAL;

public class ExposicaoDAL
{
    private List<Exposicao> _exposicoes = new List<Exposicao>();

    private static string path = "exposicao.json";

    public ExposicaoDAL()
    {
        _exposicoes = new List<Exposicao>();
    }

    public List<Exposicao> ObterTodasExposicoes()
    {
        return _exposicoes; 
    }

    public void AdicionarExposicao(Exposicao exposicao)
    {
        _exposicoes.Add(exposicao);
    }

    public void RemoverExposicao(Exposicao exposicao)
    {
        _exposicoes.Remove(exposicao);
    }

    public Exposicao ObterExposicaoPorNome(string nome)
    {
        return _exposicoes.FirstOrDefault(exposicao => exposicao.Nome == nome);
    }

    public void AtualizarExposicao(Exposicao exposicao)
    {
        var exposicaoAtualizada = ObterExposicaoPorNome(exposicao.Nome);
        exposicaoAtualizada.Nome = exposicao.Nome; 
    }

    public void GravarExposicaoFic(List<Exposicao> _exposicoes)
    {
        var json = JsonSerializer.Serialize(_exposicoes);
        File.WriteAllText(path, json);
    }

    public List<Exposicao> CarregarExposicaoFic()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            _exposicoes = JsonSerializer.Deserialize<List<Exposicao>>(json);
            return _exposicoes;
        }
        return new List<Exposicao>();
    }

    public void SalvarExposicaoFic()
    {
        var json = JsonSerializer.Serialize(_exposicoes);
        File.WriteAllText(path, json);
    }

    public void CarregarExposicaoFic(List<Exposicao> _exposicoes)
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            _exposicoes = JsonSerializer.Deserialize<List<Exposicao>>(json);
        }
    }








}
