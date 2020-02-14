using Xamarin.Forms;

namespace GloboChat.Apresentacao.Aplicativo.View
{
    public class GloboChatNavigationPage : NavigationPage
    {
        public GloboChatNavigationPage(Page page) : base(page)
        {

        }

        void SetColor()
        {
            BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            BarTextColor = (Color)Application.Current.Resources["PrimaryTextColor"];
        }
    }
}
