using Bussiness.Interface;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassesController : ControllerBase
{
    private readonly IClassService _classService;

    public ClassesController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    [Route("getList")]

    public IQueryable<Class> GetList()
    {
        return _classService.GetList();
    }

    [HttpGet]
    [Route("get")]

    public Class Get(string id)
    {
        return _classService.Get(id);
    }

    [HttpPost]
    [Route("add")]

    public string Add(Class clas)
    {
        return _classService.Add(clas).ToString();
    }

    [HttpPost]
    [Route("update")]
    public string Update(Class clas)
    {
        return _classService.Update(clas).ToString();
    }

    [HttpDelete]
    [Route("delete")]

    [Authorize(Roles = "Admin")]
    public string Update(string id)
    {
        return _classService.Delete(new Entity.Models.Class() { Id= Guid.Parse( id)}).ToString();
    }
}
