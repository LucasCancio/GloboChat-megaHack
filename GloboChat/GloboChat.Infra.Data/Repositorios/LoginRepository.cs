using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace GloboChat.Infra.Data.Repositorios
{
    public class LoginRepository : RepositoryBase<Login>, ILoginRepository
    {
        public bool Logar(string CPF, string senha)
        {            
            var login = context.Set<Login>().Where(x => x.CPF == CPF).SingleOrDefault();
            return login != null;
        }
    }
}
