using Bussiness.Interface;
using Dal.DIRepository;
using Dal.Interface;
using Entity.Context;
using Entity.Models;
using Entity.Models.Logs;
using Entity.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager;

public class LogManager : ILogService
{
    private readonly ILogDal _logDal;

    public LogManager(ILogDal logDal)
    {
        _logDal = logDal;
    }

    public Log Get(string id)
        => _logDal.Get(x => x.Id == Guid.Parse(id));

    public IQueryable<Log> GetList(Expression<Func<Log, bool>> filter = null)
        => _logDal.GetList(filter);

    public Guid Add(Log log)
        => _logDal.Add(log);

    public Guid Delete(Log log)
        => _logDal.Delete(log);

    public Guid Update(Log log)
        => _logDal.Update(log);
    public ProccessResult<IQueryable<LogView>> Serach(LogSerachCriteria criteria)
    { 
        MyDbContext dbContext= new();
        var logs = (from l in dbContext.Logs
                    select new LogView
                    {
                        Id = l.Id,
                        UserID = l.UserID,
                        UserName = "admin",
                        Ip4 = l.Ip4,
                        IP6 = l.IP6,
                        Url = l.Url,
                        Operation = l.Operation,
                        CreatedDateTime = l.CreatedDateTime,
                        Status = l.Status,
                    }).OrderBy(x=>x.CreatedDateTime).AsQueryable();

        var result = new ProccessResult<IQueryable<LogView>>(logs);
        result.Success = true;
        return result;
    }
}



