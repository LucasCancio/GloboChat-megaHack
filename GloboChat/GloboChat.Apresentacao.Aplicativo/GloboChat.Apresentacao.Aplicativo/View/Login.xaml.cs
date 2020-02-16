using GloboChat.Apresentacao.Aplicativo.Services;
using GloboChat.Apresentacao.Aplicativo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GloboChat.Apresentacao.Aplicativo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            var loginvm = new LoginViewModel();
            this.BindingContext = loginvm;

            loginvm.RedirecionarPagina += async () =>
            {
                Navigation.InsertPageBefore(new UsuarioCadastro(), this);
                await Navigation.PopAsync();
            };
            loginvm.LoginFalhou += () => DisplayAlert("Erro", "Login Inválido, tente novamente", "OK");


            InitializeComponent();
        }
    }
}