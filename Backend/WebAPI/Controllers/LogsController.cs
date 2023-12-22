using Bussiness.Interface;
using Entity.Models.Logs;
using Entity.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : BaseController
    {
        private ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [Route("Search")]
        [HttpPost]

        public ProccessResult<IQueryable<LogView>> Search([FromBody] LogSerachCriteria logSerachCriteria) {
            
            return _logService.Serach(logSerachCriteria);
        }

    }
}
