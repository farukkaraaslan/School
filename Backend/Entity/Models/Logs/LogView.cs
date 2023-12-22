using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Logs;

public class LogView : BaseEntity
{
    public Guid UserID { get; set; }
    public string UserName { get; set; }
    public string Ip4 { get; set; }
    public string IP6 { get; set; }
    public string Url { get; set; }
    public string Operation { get; set; }
}
