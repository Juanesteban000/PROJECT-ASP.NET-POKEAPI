using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ProyectoPokemon.Models;

public class PokeApiClient
{
    private readonly HttpClient _httpClient;

    public PokeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Pokemon>> GetPokemonListAsync(int limit)
    {
        var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit={limit}");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var pokemonList = JsonConvert.DeserializeObject<PokemonList>(content);

        return pokemonList.Results;
    }

    public async Task<Pokemon> GetPokemonAsync(string name)
    {
        var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name}");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var pokemonDetails = JsonConvert.DeserializeObject<PokemonDetails>(content);

        var pokemon = new Pokemon
        {
            Name = name,
            Abilities = pokemonDetails.Abilities.Select(a => new Ability { Name = a.Ability.Name }).ToList(),
            AbilitiesString = string.Join(", ", pokemonDetails.Abilities.Select(a => a.Ability.Name)),
            ImageUrl = pokemonDetails.Sprites.FrontDefault
        };

        return pokemon;
    }
}

