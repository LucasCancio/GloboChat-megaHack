using GloboChat.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Dominio.Services
{
    public class ServiceBase<TEntity> : IDisposable where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            repository = Repository;
        }


        public TEntity Post(TEntity obj)
        {
            repository.Insert(obj);
            return obj;
        }

        public TEntity Put(TEntity obj)
        {
            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(id);
        }

        public IList<TEntity> Get() => repository.Select();

        public TEntity Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.SelectById(id);
        }

        public void Dispose()
        { }
    }
}
