using Entity.DataAccess;
using Entity.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface;

public interface ILogDal: IEntityRepository<Log>
{
}
