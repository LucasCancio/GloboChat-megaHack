using GloboChat.Apresentacao.Aplicativo.ViewModel;
using Newtonsoft.Json;

namespace GloboChat.Apresentacao.Aplicativo.Services
{
    public class LoginService : ServiceBase
    {
        public bool Logar(LoginViewModel login)
        {
            var uri = URI_GloboChatAPI + "login";
            var json = JsonConvert.SerializeObject(login);

            return string.IsNullOrEmpty(PostData(uri, "json", json));
        }
    }
}
