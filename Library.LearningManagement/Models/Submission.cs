using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class Submission
    {
        private static int lastId = 0;
        private int id = 0;
        public int Id {get; private set;}

        public Student Student {get; set;}//could make private but chose not to
        public Assignment Assignment{get; set;}

        public string Content {get; set;}
        public Submission()
        {
            Id = ++lastId;
            Content = string.Empty;
        }
        public override string ToString()
        {
            return $"{Id} {Student.Name}:  {Assignment}";
        }
    }
}