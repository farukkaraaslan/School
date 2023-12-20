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

public class StudentManager : IStudentService
{
    private readonly IStudentDal _studentDal;

    public StudentManager(IStudentDal studentDal)
    {
        _studentDal = studentDal;
    }

    public Student Get(string id)
           =>_studentDal.Get(x => x.Id == Guid.Parse(id));

    public IQueryable<Student> GetList(Expression<Func<Student, bool>> filter = null)
        =>_studentDal.GetList(filter);

    public Guid Add(Student student)
        => _studentDal.Add(student);

    public Guid Delete(Student student)
          =>_studentDal.Delete(student);
  
    public Guid Update(Student student)
        =>_studentDal.Update(student);
}
