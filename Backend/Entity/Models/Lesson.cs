using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models;

public class Lesson: BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public List<Teacher> Teachers { get; set; }
    public Lesson()
    {
        
    }
}
