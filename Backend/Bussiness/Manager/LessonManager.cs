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
public class LessonManager : ILessonService
{
    private readonly ILessonDal _lessonDal;

    public LessonManager(ILessonDal lessonDal)
    {
        _lessonDal = lessonDal;
    }

    public Guid Add(Lesson lesson)
        => _lessonDal.Add(lesson);

    public Guid Update(Lesson lesson)
        => _lessonDal.Update(lesson);

    public Guid Delete(Lesson lesson)
        => _lessonDal.Delete(lesson);

    public Lesson Get(Expression<Func<Lesson, bool>> filter = null)
        => _lessonDal.Get(filter);

    public IQueryable<Lesson> GetList(Expression<Func<Lesson, bool>> filter = null)
         => _lessonDal.GetList(filter);
    


}
