using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models;

public class Student : BaseEntity
{
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public BigInteger StudentNumber { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public Student()
    {
        
    }
    public Student(string firstName, string lastName,string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}
