﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Dominio.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        void Dispose();
    }
}
