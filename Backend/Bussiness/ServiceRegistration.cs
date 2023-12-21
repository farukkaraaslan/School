using Bussiness.Interface;
using Bussiness.Manager;
using Dal.DIRepository;
using Dal.Interface;
using Entity.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness;

public static class ServiceRegistration
{
    public static void AddBusinessService(this IServiceCollection services)
    {
        services.AddScoped<IStudentService,StudentManager>();
        services.AddScoped<IClassService, ClassManager>();
    }
}
