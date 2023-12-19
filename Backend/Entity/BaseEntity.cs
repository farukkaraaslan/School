using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public Guid CreatorId { get; set; }
    public int Status { get; set; }
}
