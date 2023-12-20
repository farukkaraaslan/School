using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interface;

public interface IStudentService
{
    Student Get(string id);
    IQueryable<Student> GetList(Expression<Func<Student,bool>> filter= null);
    Guid Add(Student student);
    Guid Delete(Student student);
    Guid Update(Student student);
}
