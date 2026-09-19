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

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }
    }
}