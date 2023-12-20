using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace Entity.Helper;

public class Configuration
{
    static public string ConnectionString {
        get{
            ConfigurationManager configurationManger = new();
            configurationManger.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
            configurationManger.AddJsonFile("appsettings.json")
                ;
            return configurationManger.GetConnectionString("PostgreSQL");
        }
    }
}
