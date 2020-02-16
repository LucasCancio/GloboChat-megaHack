using GloboChat.Apresentacao.Aplicativo.ViewModel;
using Newtonsoft.Json;

namespace GloboChat.Apresentacao.Aplicativo.Services
{
    public class LoginService : ServiceBase
    {
        public bool Logar(string cpf, string senha)
        {
            var loginVModel = new LoginViewModel()
            {
                CPF = cpf,
                Senha = senha
            };
            var uri = URI_GloboChatAPI + "login";
            var json = JsonConvert.SerializeObject(loginVModel);

            return string.IsNullOrEmpty(PostData(uri, "json", json));
        }
    }
}
