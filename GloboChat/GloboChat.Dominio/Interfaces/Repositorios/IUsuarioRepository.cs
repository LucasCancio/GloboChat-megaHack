using GloboChat.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario SelectByCPF(string cpf);
        void AlterarSenha(int id, string novaSenha);
        void AlterarTelefone(int id, string telefone);
    }
}
