using PokemonPrism.Services.Impl;
using PokemonPrism.Services.Interfaces;
using PokemonPrism.ViewModels;
using PokemonPrism.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PokemonPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ListagemPokemonsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register(typeof(IPokemonService), typeof(InMemoryPokemonService));

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HelloPrismPage, HelloPrismPageViewModel>();
            containerRegistry.RegisterForNavigation<OutraPaginaPage, OutraPaginaPageViewModel>();
            //identificador personalizado da página
            //containerRegistry.RegisterForNavigation<OutraPaginaPage, OutraPaginaPageViewModel>("PaginaTeste");
            containerRegistry.RegisterForNavigation<ListagemPokemonsPage, ListagemPokemonsPageViewModel>();
            containerRegistry.RegisterForNavigation<CriarPokemonPage, CriarPokemonPageViewModel>();
            containerRegistry.RegisterForNavigation<EditarPokemonPage, EditarPokemonPageViewModel>();
            containerRegistry.RegisterForNavigation<DetalhesPokemonPage, DetalhesPokemonPageViewModel>();
        }
    }
}
