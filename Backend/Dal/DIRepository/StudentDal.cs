using Dal.Interface;
using Entity.Context;
using Entity.DataAccess;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DIRepository;

public class StudentDal : EntityRepositoryBase<Student, MyDbContext>, IStudentDal
{
}
