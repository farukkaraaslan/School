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
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Student> Students { get; set; }
    public Lesson()
    {
        
    }
}
