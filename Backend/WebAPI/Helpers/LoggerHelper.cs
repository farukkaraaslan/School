using Bussiness.Interface;
using Entity.Models.Logs;
using Microsoft.Extensions.Primitives;
using static WebAPI.Helpers.EnumHelper;

namespace WebAPI.Helpers;

public class LoggerHelper
{
    private IHttpContextAccessor _contextAccessor;
    private Log log;
    private DateTimeHelper _dateTimeHelper;
    private ILogService _logService;

    public LoggerHelper(IHttpContextAccessor contextAccessor, ILogService logService)
    {
        _contextAccessor = contextAccessor;
        this.log = new Log();
        _dateTimeHelper = new();
        _logService = logService;
    }
    public void CreateLog(string url, string operation,string userId="00000000-0000-0000-0000-000000000000")
    {
        log.UserID = Guid.Parse(userId);
        log.Ip4 = _contextAccessor.HttpContext.Request.Host.Value;
        log.IP6 = "";
        log.Url= url;
        log.Operation = operation;
        log.CreatedDateTime = _dateTimeHelper.GetDateTime;
        log.Status=(int)LogStatus.Active;
        _logService.Add(log);

    }
    private string GetValues(string key)
    {
        if (_contextAccessor.HttpContext.Request.Headers.TryGetValue(key, out StringValues headeValues) && headeValues.Any())
        {
            return headeValues.First();

        }
        return string.Empty;
    }
}
