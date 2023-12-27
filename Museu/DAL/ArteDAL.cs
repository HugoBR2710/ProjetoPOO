using System.Text.Json;
using Museu;
using static System.String;

namespace DAL;

public class ArteDAL
{
    private const string path = "arte.json";

    private List<Arte> _obrasDeArte = new List<Arte>();

    public List<Arte> ObterTodasObrasDeArte()
    {
        return _obrasDeArte;
    }


    public void AdicionarObra(Arte obraDeArte)
    {
        _obrasDeArte.Add(obraDeArte);
    }

    public void RemoverObra(Arte obraDeArte)
    {
        _obrasDeArte.Remove(obraDeArte);
    }

    public Arte ObterObraPorNome(string nome)
    {
        return _obrasDeArte.FirstOrDefault(obra => obra.Titulo == nome);
    }

    public Arte ObterObraPorNome(string nome, string tipo)
    {
        return _obrasDeArte.FirstOrDefault(obra => obra.Titulo == nome && obra.TipoArte == tipo);
    }

    public Arte ObterObraPorNome(string nome, string tipo, string autor)
    {
        return _obrasDeArte.FirstOrDefault(obra => obra.Titulo == nome && obra.TipoArte == tipo && obra.Autor == autor);
    }


    public Arte ObterObraPorNome(string nome, string tipo, string autor, int ano)
    {
        return _obrasDeArte.FirstOrDefault(obra => obra.Titulo == nome && obra.TipoArte == tipo && obra.Autor == autor && obra.AnoCriacao == ano);
    }

    
    public void AtualizarObra(Arte obraDeArte)
    {
        var obra = ObterObraPorNome(obraDeArte.Titulo, obraDeArte.TipoArte, obraDeArte.Autor, obraDeArte.AnoCriacao);
        obra.Titulo = obraDeArte.Titulo;
        obra.TipoArte = obraDeArte.TipoArte;
        obra.Autor = obraDeArte.Autor;
        obra.AnoCriacao = obraDeArte.AnoCriacao;
    }

    public void GravarObraFic(List<Arte> _obrasDeArte)
    {
        var json = JsonSerializer.Serialize(_obrasDeArte);
        File.WriteAllText(path, json);
    }

    public List<Arte> CarregarObraFic()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            _obrasDeArte = JsonSerializer.Deserialize<List<Arte>>(json);
            return _obrasDeArte;

        }

        return new List<Arte>();
    }

    public void RemoverObra(string titObra)
    {
        List<Arte> obraArt = CarregarObraFic();
        Arte obraARemover = obraArt.FirstOrDefault(obra => obra.Titulo == titObra);

        if (obraARemover != null)
        {
            obraArt.Remove(obraARemover);
            GravarObraFic(obraArt);
            Console.WriteLine($"A obra '{titObra}' foi removida do acervo");
        }
        else
        {
            Console.WriteLine($"A obra '{titObra}' não foi encontrada no acervo");
        }

    }

   
}