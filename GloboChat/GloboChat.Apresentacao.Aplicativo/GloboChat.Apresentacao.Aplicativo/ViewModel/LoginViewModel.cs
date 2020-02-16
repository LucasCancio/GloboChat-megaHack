using GloboChat.Apresentacao.Aplicativo.Services;
using GloboChat.Apresentacao.Aplicativo.View;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace GloboChat.Apresentacao.Aplicativo.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string cpf;
        public string CPF
        {
            get { return cpf; }
            set
            {
                cpf = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CPF"));
            }
        }
        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Senha"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public Action RedirecionarPagina;
        public Action LoginFalhou;

        public ICommand LoginCommand { protected set; get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Logar);
        }

        public void Logar()
        {
            var login = new LoginService();

            var isValid = login.Logar(cpf, senha);
            if (isValid)
            {
                //App.IsUserLoggedIn = true;
                RedirecionarPagina();
            }
            else
            {
                LoginFalhou();
            }
        }
    }
}
