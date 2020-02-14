using GloboChat.Apresentacao.Aplicativo.Helpers;
using MvvmHelpers;

namespace GloboChat.Apresentacao.Aplicativo.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {

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

        public string ServerIP
        {
            get => Settings.ServerIP;
            set
            {
                if (value == ServerIP)
                    return;
                Settings.ServerIP = value.ToLower();
                OnPropertyChanged();
            }
        }

    }
}
