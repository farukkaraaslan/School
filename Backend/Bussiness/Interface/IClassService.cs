using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interface;

public interface IClassService
{
    Class Get(string id);
    IQueryable<Class> GetList(Expression<Func<Class, bool>> filter = null);
    Guid Add(Class clas);
    Guid Delete(Class clas);
    Guid Update(Class clas);
}
