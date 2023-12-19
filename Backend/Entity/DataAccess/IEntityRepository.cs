using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataAccess;

public interface IEntityRepository<T>
	where T : BaseEntity, new()
{
	T Get(Expression<Func<T, bool>> filter = null);
	IQueryable<T> GetList(Expression<Func<T,bool>> filter = null); //Iquerybledirek sunucu tarafında sorgulama yapılır
	Guid Add(T entity);
	Guid Update(T entity);
	Guid Delete(T entity);	
}

