using Bussiness.Interface;
using Dal.Interface;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager;

public class ClassManager : IClassService
{
    private readonly IClassDal _classDal;

    public ClassManager(IClassDal classDal)
    {
        _classDal = classDal;
    }

    public Class Get(Expression<Func<Class, bool>> filter = null)
        => _classDal.Get(filter);

    public IQueryable<Class> GetList(Expression<Func<Class, bool>> filter = null)
        =>_classDal.GetList(filter);

    public Guid Add(Class clas)
        => _classDal.Add(clas);

    public Guid Delete(Class clas)
        =>_classDal.Delete(clas);

    public Guid Update(Class clas)
        => _classDal.Update(clas);
}
