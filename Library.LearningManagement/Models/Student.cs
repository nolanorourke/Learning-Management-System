using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class Student: Person
    {
        public PersonClassification Classification{get;set;}

        public Dictionary<int, double> Grades {get; set;}

        public Student()
        {
            Grades = new Dictionary<int, double>();

        }

        public override string ToString()
        {
            return $"[{Id}]  {Name} -  {Classification}";
        }

    }
    public enum PersonClassification
    {
        Freshman, Sophomore, Junior, Senior
    }

}