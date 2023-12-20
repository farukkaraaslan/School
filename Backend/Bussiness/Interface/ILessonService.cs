using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interface;

public interface ILessonService
{
    Lesson Get(string id);
    IQueryable<Lesson> GetList(Expression<Func<Lesson, bool>> filter = null);
    Guid Add(Lesson lesson);
    Guid Delete(Lesson lesson);
    Guid Update(Lesson  lesson);
}
