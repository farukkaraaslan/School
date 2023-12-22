using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Service;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecretController : BaseController
{
    private readonly IHostEnvironment _hostEnvironment;

    public SecretController(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    [HttpPut]
    [Route("writescret")]

    public string WriteSecret()
    {
        string secretString = "Server= localhost;Port=5432;Database=jsga; User Id=root; Password=1234;";

        DataProtector dataPretector = new DataProtector(_hostEnvironment.ContentRootPath);

        int lenght= dataPretector.EncryptData(secretString);
        return "Scret line wrote successfuly";
    }

    [HttpGet]
    [Route("readscret")]
    public string ReadSecret()
    {
     
        DataProtector dataPretector = new DataProtector(_hostEnvironment.ContentRootPath);
        string lenght = dataPretector.DecryptData();
        return lenght;
    }
}
