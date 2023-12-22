using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Logs;

public class LogSerachCriteria
{
    public string DateTime { get; set; }
    public int LogType { get; set; }
    public string SearchText { get; set; }
}
