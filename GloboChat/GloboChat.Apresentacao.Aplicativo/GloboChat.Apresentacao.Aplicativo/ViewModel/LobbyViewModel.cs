using GloboChat.Apresentacao.Aplicativo.Helpers;
using GloboChat.Apresentacao.Aplicativo.Services;
using GloboChat.Apresentacao.Aplicativo.View;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GloboChat.Apresentacao.Aplicativo.ViewModel
{
    public class LobbyViewModel : ViewModelBase
    {
        public List<string> Rooms { get; }
        public LobbyViewModel()
        {
            Rooms = ChatService.GetRooms();
        }

        public string UserName
        {
            get => Settings.UserName;
            set
            {
                if (value == UserName)
                    return;
                Settings.UserName = value;
                OnPropertyChanged();
            }
        }


        public async Task GoToCanalChat(INavigation navigation, string group)
        {
            if (string.IsNullOrWhiteSpace(group))
                return;

            if (string.IsNullOrWhiteSpace(UserName))
                return;

            Settings.Group = group;
            await navigation.PushModalAsync(new GloboChatNavigationPage(new CanalChatPage()));
        }

    }
}
