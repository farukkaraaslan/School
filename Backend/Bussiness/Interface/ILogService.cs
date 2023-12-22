using Entity.Models;
using Entity.Models.Logs;
using Entity.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interface;

public interface ILogService
{
    Log Get(string id);
    IQueryable<Log> GetList(Expression<Func<Log, bool>> filter = null);
    Guid Add(Log log);
    Guid Delete(Log log);
    Guid Update(Log log);
    ProccessResult<IQueryable<LogView>>  Serach(LogSerachCriteria criteria);
}
