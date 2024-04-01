using System.Reflection.Metadata.Ecma335;

namespace Library.LearningManagement.Models
{
    //the stuff you see on modules, links essentially
    public class ContentItem
    {
        private static int lastId = 0;
        private int id = 0;
        public int Id {
            get; private set;
        }
        public string? Name{get;set;}

        public string? Description{get;set;}

        public override string ToString()
        {
            return $"{Name}:  {Description}";
        }

        public ContentItem()
        {
            Id = ++lastId;
        }
    }


}