using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class PokemonController : Controller
{
    private readonly PokeApiClient _pokeApiClient;

    public PokemonController(PokeApiClient pokeApiClient)
    {
        _pokeApiClient = pokeApiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var pokemons = await _pokeApiClient.GetPokemonListAsync(20);

        return View(pokemons);
    }

    [HttpGet("Detalle/{name}")]
    public async Task<IActionResult> Detalle(string name)
    {
        var pokemon = await _pokeApiClient.GetPokemonAsync(name);

        return View(pokemon);
    }

}
