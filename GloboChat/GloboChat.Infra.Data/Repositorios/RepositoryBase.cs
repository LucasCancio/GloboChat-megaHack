using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloboChat.Infra.Data.Repositorios
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		protected GloboChatContext context;
		public RepositoryBase(GloboChatContext Context)
		{
			context = Context;
		}

		public void Insert(TEntity obj)
		{
			context.Set<TEntity>().Add(obj);
			context.SaveChanges();
		}

		public void Update(TEntity obj)
		{
			context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			context.Set<TEntity>().Remove(SelectById(id));
			context.SaveChanges();
		}

		public virtual IList<TEntity> Select()
		{
			return context.Set<TEntity>().ToList();
		}

		public virtual TEntity SelectById(int id)
		{
			return context.Set<TEntity>().Find(id);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
