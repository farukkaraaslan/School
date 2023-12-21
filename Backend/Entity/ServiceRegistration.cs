using Entity.Context;
using Entity.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity;

public static class ServiceRegistration
{
    public static void AddEntityServices(this IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));

    }
}