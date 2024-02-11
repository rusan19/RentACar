using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, new()
    {
        public void Add(TEntity entity);
        public void Delete(int id);
        public void Update(TEntity entity);
        public TEntity Get(Expression<Func<TEntity, bool>> filter);
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null);
    }
}
