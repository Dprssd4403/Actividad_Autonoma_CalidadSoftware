using System.Text.Json.Serialization;

namespace Actividad_Autonoma.Models
{
    public class PokemonDetail
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }

        [JsonPropertyName("abilities")]
        public List<AbilityItem> Abilities { get; set; }

        [JsonPropertyName("types")]
        public List<TypeItem> Types { get; set; }

        public string ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
    }

    public class AbilityItem
    {
        [JsonPropertyName("ability")]
        public NamedResource Ability { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }
    }

    public class TypeItem
    {
        [JsonPropertyName("type")]
        public NamedResource Type { get; set; }
    }

    public class NamedResource
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}