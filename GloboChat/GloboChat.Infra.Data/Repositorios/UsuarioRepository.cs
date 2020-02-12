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
            throw new NotImplementedException();
        }

        public void AlterarTelefone(int id, string novoCelular)
        {
            throw new NotImplementedException();
        }

        public Usuario SelectByCPF(string cpf)
        {
            return context.Set<Usuario>().Where(x=>x.CPF==cpf).SingleOrDefault();
        }
    }
}
