using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace FilmesAPI.Controllers;

[ApiController]
// é o mesmo que usar o [Route("Filme")], pois ele já pega o nome que está
// no controler. Caso mude o nome do controler, não precisaria alterar o
// route.
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    public static List<Filme> filmes = new List<Filme>();
    public static int id = 0;

    [HttpPost]
    public void Adciciona([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Duracao);
    }

    /* 
       IEnumerable é a mesma coisa que List, só que IEnumerable é a
       interface, então fica mais fácil caso seja alterado futuramente
       para outro tipo de coleção.

       [FromQuery] informa que a informação está vindo da query "filme?skip=10&take=5" 
       informada pelo usuário.

       O método Skip() indica quantos elementos da lista pular, enquanto o
       Take() define quantos serão selecionados
     */
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return filmes.Skip(skip).Take(take);
    }

    // seria a rota "Filme/id"
    [HttpGet("{id}")]
    public Filme? RecuperaFilmePorId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
