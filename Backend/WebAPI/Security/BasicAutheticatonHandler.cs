using Entity.Context;
using Entity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using WebAPI.Service;

namespace WebAPI.Security;

public class BasicAutheticatonHandler : AuthenticationHandler<BasicAuthenticationOption>
{
    private readonly UserService _userService;
private readonly MyDbContext    _dbContext;
    public BasicAutheticatonHandler(
        IOptionsMonitor<BasicAuthenticationOption> options,
        ILoggerFactory loggerFactory,
        UrlEncoder urlEncoder,
        ISystemClock systemClock) : base(options, loggerFactory, urlEncoder, systemClock)
    { 
    
        _userService = new UserService();
        _dbContext = new MyDbContext();
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
        {
            return AuthenticateResult.NoResult();
        }

        byte[] incommingCredential = Convert.FromBase64String(headerValue.Parameter);

        string userCredential = Encoding.UTF8.GetString(incommingCredential);
        string userName = userCredential.Split(':')[0];
        string password = userCredential.Split(':')[1];
        Student student = _dbContext.Students.SingleOrDefault(s=>s.FirstName == userName  && s.Password==password);

        if (student == null)
        {
            return AuthenticateResult.Fail("Wrong username and password");
        }

        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, student.FirstName),
            new Claim(ClaimTypes.Email, student.Email),
    
        };

        ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
        AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
