﻿using DAL;
using Museu;

namespace BLL;

public class ArteBLL
{
    private ArteDAL arteDAL;

    

    public ArteBLL()
    {
        arteDAL = new ArteDAL();
    }

    public List<Arte> ObterTodasObrasDeArte()
    {
        return arteDAL.ObterTodasObrasDeArte();
    }


    public void AdicionarObra(Arte arte)
    {
        arteDAL.AdicionarObra(arte);
    }

    public void RemoverObra(Arte arte)
    {
        arteDAL.RemoverObra(arte);
    }

    public Arte ObterObraPorNome(string nome)
    {
        return arteDAL.ObterObraPorNome(nome);
    }


    public Arte ObterObraPorNome(string nome, string tipo, string autor, int ano)
    {
        return arteDAL.ObterObraPorNome(nome, tipo, autor, ano);
    }


    public void AtualizarObra(Arte arte)
    {
        arteDAL.AtualizarObra(arte);
    }

    public void GravarObraFic(List<Arte> _obrasDeArte)
    {
        arteDAL.GravarObraFic(_obrasDeArte);
    }

 
    public List<Arte> CarregarObraFic()
    {
        return arteDAL.CarregarObraFic();
    }

    public void RemoverObra(string nome)
    {
        try
        {
            arteDAL.RemoverObra(nome);
        }
        catch (Exception e)
        {
            Console.WriteLine("não foi possível remover a Obra");
            throw;
        }
        
    }

}