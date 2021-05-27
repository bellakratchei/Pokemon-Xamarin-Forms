using PokemonPrism.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PokemonPrism.Services.Interfaces
{
    public interface IPokemonService
    {
        ObservableCollection<PokemonViewModel> All();

        void Insert(PokemonViewModel pokemon);
        void Update(PokemonViewModel pokemon);
        void Delete(PokemonViewModel pokemon);
    }
}
