using System.Text.Json.Serialization;

namespace Actividad_Autonoma.Models
{
    public class PokemonResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonItem> Results { get; set; }
    }

    public class PokemonItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        public int Id
        {
            get
            {
                var segments = Url?.TrimEnd('/').Split('/');
                return segments != null && int.TryParse(segments.LastOrDefault(), out int id) ? id : 0;
            }
        }

        public string ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
    }
}