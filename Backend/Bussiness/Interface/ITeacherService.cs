using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interface;

public interface ITeacherService
{
    Teacher Get(Expression<Func<Teacher, bool>> filter = null);
    IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> filter = null);
    Guid Add(Teacher teacher);
    Guid Delete(Teacher teacher);
    Guid Update(Teacher teacher);
}
