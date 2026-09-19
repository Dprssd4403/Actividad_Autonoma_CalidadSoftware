using System.Net.Http.Json;
using Actividad_Autonoma.Models;

namespace Actividad_Autonoma.Services
{
    public interface IPokemonService
    {
        Task<PokemonResponse> GetPokemonsAsync(int limit = 20, int offset = 0);
        Task<PokemonDetail> GetPokemonByIdAsync(int id);
    }

    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonResponse> GetPokemonsAsync(int limit = 20, int offset = 0)
        {
            var response = await _httpClient.GetFromJsonAsync<PokemonResponse>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}&limit={limit}");
            return response ?? new PokemonResponse();
        }

        public async Task<PokemonDetail> GetPokemonByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<PokemonDetail>($"https://pokeapi.co/api/v2/pokemon/{id}");
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}