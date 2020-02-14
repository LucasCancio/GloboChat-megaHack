using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Dominio.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            repository = Repository;
        }

        public void Add(TEntity obj)
        {
            repository.Insert(obj);
        }

        public TEntity GetById(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.SelectById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.Select();
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public void Remove(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(id);
        }


        public void Dispose()
        { }
    }
}
