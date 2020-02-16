using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Infra.Data.Contexto;
using System.Linq;

namespace GloboChat.Infra.Data.Repositorios
{
    public class LoginRepository : RepositoryBase<Login>, ILoginRepository
    {
        public LoginRepository(GloboChatContext context):base(context)
        {

        }
        public bool Logar(string CPF, string senha)
        {            
            var login = context.Set<Login>().Where(x => x.CPF == CPF).SingleOrDefault();
            return login != null;
        }
    }
}
