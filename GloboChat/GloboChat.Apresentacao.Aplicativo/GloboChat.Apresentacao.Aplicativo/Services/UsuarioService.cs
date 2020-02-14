using GloboChat.Apresentacao.Aplicativo.ViewModel;
using Newtonsoft.Json;

namespace GloboChat.Apresentacao.Aplicativo.Services
{
    public class UsuarioService : ServiceBase
    {
        public bool Alterar(UsuarioViewModel user)
        {
            var uri = URI_GloboChatAPI + "usuario";
            var json = JsonConvert.SerializeObject(user);

            return string.IsNullOrEmpty(PostData(uri, "json", json));  
        }
    }
}
