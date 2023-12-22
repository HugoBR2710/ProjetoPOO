﻿using Museu;

namespace DAL;

public class ArteDAL
{



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

}