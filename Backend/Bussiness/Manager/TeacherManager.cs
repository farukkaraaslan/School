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

public class TeacherManager : ITeacherService
{
    private readonly ITeacherDal _teacherDal;

    public TeacherManager(ITeacherDal teacherDal)
    {
        _teacherDal = teacherDal;
    }

    public Teacher Get(Expression<Func<Teacher, bool>> filter = null)
        => _teacherDal.Get(filter); 

    public IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> filter = null)
        => _teacherDal.GetList(filter);

    public Guid Add(Teacher teacher)
        => _teacherDal.Add(teacher);

    public Guid Delete(Teacher teacher)
        =>_teacherDal.Delete(teacher);

    public Guid Update(Teacher teacher)
        => _teacherDal.Update(teacher);
}
