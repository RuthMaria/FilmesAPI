using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
// é o mesmo que usar o [Route("Filme")], pois ele já pega o nome que está no controler. Caso mude o nome do controler, não precisaria alterar o route.
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    public static List<Filme> filmes = new List<Filme>();

    [HttpPost]    
    public void Adciciona([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine(filme.Duracao);
    }
}
