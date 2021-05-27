using PokemonPrism.Services.Interfaces;
using PokemonPrism.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PokemonPrism.Services.Impl
{
    public class InMemoryPokemonService : IPokemonService
    {
        private static ObservableCollection<PokemonViewModel> _pokemons = new ObservableCollection<PokemonViewModel>();

        public InMemoryPokemonService()
        {
            
        }

        public ObservableCollection<PokemonViewModel> All()
        {
            if(_pokemons.Count == 0)
            {
                _pokemons.Add(new PokemonViewModel
                {
                    Numero = 1,
                    Nome = "Bulbassauro"
                });
            }

            return _pokemons;
        }

        public void Delete(PokemonViewModel pokemon)
        {
            _pokemons.Remove(pokemon);
        }

        public void Insert(PokemonViewModel pokemon)
        {
            _pokemons.Add(pokemon);
        }

        public void Update(PokemonViewModel pokemon)
        {
            
        }
    }
}
