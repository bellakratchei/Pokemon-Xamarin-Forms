using PokemonPrism.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPrism.ViewModels
{
    public class CriarPokemonPageViewModel : BindableBase
    {
        private IPokemonService _pokemonService;
        private INavigationService _navigationService;

        private PokemonViewModel _pokemon = new PokemonViewModel();
        public PokemonViewModel Pokemon
        {
            get { return _pokemon; }
            set { SetProperty(ref _pokemon, value); }
        }

        public DelegateCommand SalvarCommand 
        { 
            get
            {
                return new DelegateCommand(() =>
                {
                    _pokemonService.Insert(_pokemon);
                    _navigationService.GoBackAsync();
                });
            }
        }

        public CriarPokemonPageViewModel(INavigationService navigationService, IPokemonService pokemonService)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
        }
    }
}
