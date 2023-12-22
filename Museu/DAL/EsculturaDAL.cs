using System.Runtime.CompilerServices;
using System.Text.Json;
using Museu;

namespace DAL;

public class EsculturaDAL
{
    private List<Escultura> _escultura = new List<Escultura>();

    private const string path = "escultura.json";

    public List<Escultura> ObterTodasEsculturas()
    {
        return _escultura;
    }

    public void AdicionarEscultura(Escultura escultura)
    {
        _escultura.Add(escultura);
    }

    public void RemoverEscultura(Escultura escultura)
    {
        _escultura.Remove(escultura);
    }

    public Escultura ObterEsculturaPorNome(string nome)
    {
        return _escultura.FirstOrDefault(escultura => escultura.Titulo == nome);
    }

    public Escultura ObterEsculturaPorNome(string nome, string tipo)
    {
        return _escultura.FirstOrDefault(escultura => escultura.Titulo == nome && escultura.TipoArte == tipo);
    }

    public Escultura ObterEsculturaPorNome(string nome, string tipo, string autor)
    {
        return _escultura.FirstOrDefault(escultura => escultura.Titulo == nome && escultura.TipoArte == tipo && escultura.Autor == autor);
    }

    public Escultura ObterEsculturaPorNome(string nome, string tipo, string autor, int ano)
    {
        return _escultura.FirstOrDefault(escultura => escultura.Titulo == nome && escultura.TipoArte == tipo && escultura.Autor == autor && escultura.AnoCriacao == ano);
    }


    public void AtualizarEscultura(Escultura escultura)
    {
        var obra = ObterEsculturaPorNome(escultura.Titulo, escultura.TipoArte, escultura.Autor, escultura.AnoCriacao);
        obra.Titulo = escultura.Titulo;
        obra.TipoArte = escultura.TipoArte;
        obra.Autor = escultura.Autor;
        obra.AnoCriacao = escultura.AnoCriacao;
    }

    public void SalvarEscultura()
    {
        var json = JsonSerializer.Serialize(_escultura);
        File.WriteAllText(path, json);
    }

    public void CarregarEscultura()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            _escultura = JsonSerializer.Deserialize<List<Escultura>>(json);
        }
    }
     

}