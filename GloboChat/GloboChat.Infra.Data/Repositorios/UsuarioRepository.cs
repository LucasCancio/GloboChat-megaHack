using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloboChat.Infra.Data.Repositorios
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public void AlterarSenha(int id, string novaSenha)
        {
            var user= context.Set<Usuario>().Where(x => x.Id == id).SingleOrDefault();
            user.pessoa.login.Senha = novaSenha;

            Update(user);
        }

        public void AlterarTelefone(int id, string telefone)
        {
            var user = context.Set<Usuario>().Where(x => x.Id == id).SingleOrDefault();
            user.pessoa.Telefone = telefone;

            Update(user);
        }

        public Usuario SelectByCPF(string cpf)
        {
            return context.Set<Usuario>().Where(x=>x.pessoa.login.CPF==cpf).SingleOrDefault();
        }
    }
}
