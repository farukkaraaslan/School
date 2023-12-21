using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataAccess;

public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : BaseEntity, new()
    where TContext : DbContext, new()
{
    public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            return filter == null
                ? context.Set<TEntity>().AsQueryable()
                : context.Set<TEntity>().Where(filter).AsQueryable();
        }
    }

    public Guid Add(TEntity entity)
    {
        using (var context = new TContext())
        {
            context.Add<TEntity>(entity);
            context.SaveChanges();
            return entity.Id;
        }
    }
    public Guid Update(TEntity entity)
    {
        using (var context = new TContext())
        {
            context.Update<TEntity>(entity);
            context.SaveChanges();
            return entity.Id;
        }
    }

    public Guid Delete(TEntity entity)
    {
        using (var context = new TContext())
        {
            context.Remove<TEntity>(entity);
            context.SaveChanges();
            return entity.Id;
        }
    }
}
