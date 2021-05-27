using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonPrism.ViewModels
{
    public class PokemonViewModel : BindableBase
    {
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set 
            { 
                SetProperty(ref _numero, value);
                Imagem = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{value}.png";
            }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }

        private string _imagem;
        public string Imagem
        {
            get { return _imagem; }
            set { SetProperty(ref _imagem, value); }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }

        private bool _isPrimeiraFase;
        public bool IsPrimeiraFase
        {
            get { return _isPrimeiraFase; }
            set { SetProperty(ref _isPrimeiraFase, value); }
        }
    }
}
