using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Infra.Data.Repositorios
{
    public class CanalRepository : RepositoryBase<Canal>, ICanalRepository
    {
        public CanalRepository(GloboChatContext context) :base(context)
        {

        }
    }
}
