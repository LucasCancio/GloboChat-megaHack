using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GloboChat.Infra.Data.Repositorios
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GloboChatContext context):base(context)
        {

        }

        public override Usuario SelectById(int id)
        {
            var user = context.Usuarios.Where(u=>u.Id==id)
                .Include(u => u.pessoa)
                .ThenInclude(p=>p.login)
                .FirstOrDefault();

            return user;
        }

        public void AlterarSenha(int id, string novaSenha)
        {
            var user= context.Usuarios.Where(x => x.Id == id).SingleOrDefault();
            user.pessoa.login.Senha = novaSenha;

            Update(user);
        }

        public void AlterarTelefone(int id, string telefone)
        {
            var user = context.Usuarios.Where(x => x.Id == id).SingleOrDefault();
            user.pessoa.Telefone = telefone;

            Update(user);
        }

        public Usuario SelectByCPF(string cpf)
        {
            var user = context.Usuarios.Where(u => u.pessoa.login.CPF == cpf)
                .Include(u => u.pessoa)
                .ThenInclude(p => p.login)
                .FirstOrDefault();

            return user;
        }
    }
}
