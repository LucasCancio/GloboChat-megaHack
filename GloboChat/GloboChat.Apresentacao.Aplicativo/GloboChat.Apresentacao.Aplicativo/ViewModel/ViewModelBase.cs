using GloboChat.Apresentacao.Aplicativo.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace GloboChat.Apresentacao.Aplicativo.ViewModel
{
    public class ViewModelBase : BaseViewModel
    {
        ChatService chatService;
        public ChatService ChatService =>
            chatService ?? (chatService = DependencyService.Resolve<ChatService>());

        DialogService dialogService;
        public DialogService DialogService =>
            dialogService ?? (dialogService = DependencyService.Resolve<DialogService>());
    }
}
