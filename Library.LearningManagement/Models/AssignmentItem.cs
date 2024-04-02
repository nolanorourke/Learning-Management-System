using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class AssignmentItem: ContentItem
    {
        public Assignment? Assignment {get; set;} //path to a server

        public override string ToString()
        {
            return $"{base.ToString()}\n{Assignment}";
        }
    }
}