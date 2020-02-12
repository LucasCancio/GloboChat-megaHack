using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Dominio.Interfaces.Repositorios
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        IList<TEntity> Select();
        TEntity SelectById(int id);
        void Dispose();
    }
}
