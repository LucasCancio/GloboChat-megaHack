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
    public partial class MainPage : ContentPage
    {

        LobbyViewModel vm;
        LobbyViewModel VM
        {
            get => vm ?? (vm = (LobbyViewModel)BindingContext);
        }
        public MainPage()
        {
            InitializeComponent();
        }


        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await VM.GoToCanalChat(Navigation, e.SelectedItem as string);
            ((ListView)sender).SelectedItem = null;
        }
    }
}