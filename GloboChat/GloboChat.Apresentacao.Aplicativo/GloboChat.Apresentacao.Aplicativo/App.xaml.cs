using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GloboChat.Apresentacao.Aplicativo.View;

namespace GloboChat.Apresentacao.Aplicativo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
