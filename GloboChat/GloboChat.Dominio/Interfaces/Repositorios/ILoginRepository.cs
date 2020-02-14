using GloboChat.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Dominio.Interfaces.Repositorios
{
    public interface ILoginRepository: IRepositoryBase<Login>
    {
        bool Logar(string CPF, string senha);
    }
}
