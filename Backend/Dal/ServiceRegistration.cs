using Dal.DIRepository;
using Dal.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

public static class ServiceRegistration
{
    public static void AddDalServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentDal, StudentDal>();
        services.AddScoped<IClassDal, ClassDal>();
        services.AddScoped<ILogDal, LogDal>();
    }
}