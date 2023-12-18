using System.Runtime.CompilerServices;
using BLL;
using Museu;

namespace PL;

public class ArtePL
{
    private ArteBLL arteBLL;

    public ArtePL()
    {
        arteBLL = new ArteBLL();
    }

    public void AdicionarObra(string titulo, String tipo, int ano, string autor)
    {
        Arte novaObra = new Arte(titulo, tipo, ano, autor);
        arteBLL.AdicionarObra(novaObra);
    }

    public void RemoverObra(Arte obra)
    {
        arteBLL.RemoverObra(obra);
    }

}