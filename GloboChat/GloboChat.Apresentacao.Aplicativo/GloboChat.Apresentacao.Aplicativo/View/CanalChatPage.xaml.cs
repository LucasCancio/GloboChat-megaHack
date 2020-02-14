using GloboChat.Apresentacao.Aplicativo.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GloboChat.Apresentacao.Aplicativo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CanalChatPage : ContentPage
    {
        public CanalChatPage()
        {
            InitializeComponent();
        }

        ChatViewModel vm;
        ChatViewModel VM
        {
            get => vm ?? (vm = (ChatViewModel)BindingContext);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!DesignMode.IsDesignModeEnabled)
                VM.ConnectCommand.Execute(null);

            ToolbarDone.Clicked += ToolbarDone_Clicked;
        }

        private async void ToolbarDone_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (!DesignMode.IsDesignModeEnabled)
                VM.DisconnectCommand.Execute(null);

            ToolbarDone.Clicked -= ToolbarDone_Clicked;
        }
    }
}