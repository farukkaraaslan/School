using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Shared;

public class ProccessResult<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public int RecordsCount { get; set; }
    public string? Message { get; set; }
    public int? Id { get; set; }

    public ProccessResult()
    {
        this.Data= default(T);
        this.Success= false;
        this.RecordsCount=0;
        this.Message= string.Empty;
    }
    public ProccessResult(int id)
    {
        this.Success = true;
        this.RecordsCount = 1;
        this.Id= id;
        this.Message = string.Empty;
    }

    public ProccessResult(T resulData)
    {
        this.Data= resulData;
        
    }
    public ProccessResult(Exception ex)
    {
        this.Success = false;
        this.Message=ex.Message;
    }
}
