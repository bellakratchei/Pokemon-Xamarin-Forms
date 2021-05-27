using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPrism.ViewModels
{
    public class HelloPrismPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set { SetProperty(ref _texto, value); }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }

        private string _mensagem;
        public string Mensagem
        {
            get { return _mensagem; }
            set { SetProperty(ref _mensagem, value); }
        }

        public DelegateCommand EnviarCommand 
        {
            get 
            {
                return new DelegateCommand(() =>
                {
                    Mensagem = $"Olá, {_nome}!";
                });
            }
        }

        public DelegateCommand IrParaOutraPaginaCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.NavigateAsync("OutraPaginaPage");
                    //_navigationService.NavigateAsync("PaginaTeste");
                });
            }
        }

        public HelloPrismPageViewModel(INavigationService navigationService)
        {
            Texto = "Bem vindo ao Prism!";
            Mensagem = string.Empty;
            _navigationService = navigationService;
        }
    }
}
