using Microsoft.AspNetCore.Mvc;
using Actividad_Autonoma.Services;

namespace Actividad_Autonoma.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index()
        {
            var pokemonList = await _pokemonService.GetPokemonsAsync();
            return View(pokemonList.Results);
        }
    }
}