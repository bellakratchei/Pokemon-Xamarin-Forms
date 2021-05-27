using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPrism.ViewModels
{
    public class DetalhesPokemonPageViewModel : BindableBase, INavigationAware
    {
        private PokemonViewModel _pokemon;
        public PokemonViewModel Pokemon
        {
            get { return _pokemon; }
            set { SetProperty(ref _pokemon, value); }
        }


        public DetalhesPokemonPageViewModel()
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Pokemon = parameters["pokemon"] as PokemonViewModel;
        }
    }
}
