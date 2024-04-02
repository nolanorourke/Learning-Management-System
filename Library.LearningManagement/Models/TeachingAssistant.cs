using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class TeachingAssistant: Person
    {

        public TeachingAssistant()
        {

        }

        public override string ToString()
        {
            return $"TA:  [{Id}]  {Name}";
        }

    }
}