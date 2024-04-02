using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class Instructor: Person
    {
        public Instructor()
        {
        }
        public override string ToString()
        {
            return $"Instructor:  [{Id}]  {Name}";
        }

    }
}