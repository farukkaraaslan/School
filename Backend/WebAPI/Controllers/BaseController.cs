using Bussiness.Interface;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers;

public class BaseController : ControllerBase
{
    public LoggerHelper logHelper;
    IHttpContextAccessor httpContextAccessor;

    public BaseController()
    {
        httpContextAccessor = new HttpContextAccessor();
        var httpContext = httpContextAccessor.HttpContext;
            ILogService logService = httpContext.RequestServices.GetService<ILogService>();
            logHelper = new LoggerHelper(httpContextAccessor, logService);
   
    }

}