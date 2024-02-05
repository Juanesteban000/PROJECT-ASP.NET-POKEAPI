namespace ProyectoPokemon.Models
{
    public class PokemonList
    {
        public List<Pokemon> Results { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public List<Ability> Abilities { get; set; }
        public string AbilitiesString { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
    }

    public class PokemonDetails
    {
        public List<PokemonAbility> Abilities { get; set; }
        public Sprites Sprites { get; set; }
    }

    public class PokemonAbility
    {
        public Ability Ability { get; set; }
    }
    public class Sprites
    {
        public string FrontDefault { get; set; }
    }
}
