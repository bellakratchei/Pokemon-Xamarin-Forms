using PokemonPrism.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PokemonPrism.ViewModels
{
    public class ListagemPokemonsPageViewModel : BindableBase, IConfirmNavigation
    {
        private IPokemonService _pokemonService;
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

        private ObservableCollection<PokemonViewModel> _pokemons = new ObservableCollection<PokemonViewModel>();

        public ObservableCollection<PokemonViewModel> Pokemons
        {
            get { return _pokemons; }
            set { SetProperty(ref _pokemons, value); }
        }

        public DelegateCommand NovoPokemonCommand 
        { 
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.NavigateAsync("CriarPokemonPage");
                });
            }
                
        }

        public DelegateCommand<PokemonViewModel> SelecionarPokemonCommand 
        { 
            get
            {          
                return new DelegateCommand<PokemonViewModel>((pokemon) =>
                {
                    IActionSheetButton editarPokemonButton = ActionSheetButton.CreateButton("Editar", () =>
                    {
                        //_pageDialogService.DisplayAlertAsync("Ação", $"Você quer editar o {pokemon.Nome}", "OK");
                        NavigationParameters parameters = new NavigationParameters();
                        parameters.Add("pokemon", pokemon);
                        parameters.Add("isEdicao", true);
                        //parameters.Add("nomePokemon", pokemon.Nome);
                        //_navigationService.NavigateAsync("EditarPokemonPage?nomePokemon=" + pokemon.Nome, parameters);
                        _navigationService.NavigateAsync("EditarPokemonPage", parameters);
                    });
                    IActionSheetButton excluirPokemonButton = ActionSheetButton.CreateDestroyButton("Excluir", async () =>
                    {
                        //_pageDialogService.DisplayAlertAsync("Ação", $"Você quer excluir o {pokemon.Nome}", "OK");
                        bool confirmarExclusao = await _pageDialogService.DisplayAlertAsync("Confirmação", 
                            $"Deseja realmente excluir o pokémon {pokemon.Nome}?", "Sim", "Não");
                        if(confirmarExclusao)
                        {
                            _pokemonService.Delete(pokemon);
                        }
                    });
                    IActionSheetButton detalharPokemonButton = ActionSheetButton.CreateButton("Detalhar", () =>
                    {
                        NavigationParameters parameters = new NavigationParameters();
                        parameters.Add("pokemon", pokemon);
                        _navigationService.NavigateAsync("DetalhesPokemonPage", parameters);
                    });
                    IActionSheetButton cancelarButton = ActionSheetButton.CreateCancelButton("Cancelar", () =>
                    {
                       
                    });

                    _pageDialogService.DisplayActionSheetAsync($"O que você quer fazer com o {pokemon.Nome}?",editarPokemonButton,
                        excluirPokemonButton,detalharPokemonButton,cancelarButton);
                });
            }
        }

        public ListagemPokemonsPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService, IPokemonService pokemonService)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _pageDialogService = pageDialogService;
            Pokemons = _pokemonService.All();
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            bool isEdicao = parameters["isEdicao"] != null;
            PokemonViewModel pokemon = parameters["pokemon"] as PokemonViewModel;
            // Guard de navegação, navegações só serão realizadas, caso atenda as regras de negócio
            if(isEdicao)
            {
                if(pokemon.IsPrimeiraFase)
                {
                    _pageDialogService.DisplayAlertAsync("Alerta!", "Pokémons de primeira fase não podem ser editados", "OK!");
                }
                return !pokemon.IsPrimeiraFase;
            }

            return true;
        }
    }
}
