using Bussiness.Interface;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : BaseController
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }


    [HttpPost]
    [Route("Add")]
    [Authorize]
    public string Add(Student student)
    {
        return _studentService.Add(student).ToString();
    }

    [HttpGet]
    [Route("GetList")]
    public IQueryable<Student> Getlist()
    {
        return _studentService.GetList();
    }
}
