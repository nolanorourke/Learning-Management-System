namespace Library.LearningManagement.Models
{
    public class Person
    {
        private static int lastId=0;
        public int Id {get; private set;}
        public string Name{get; set;} //if it is public should be captial, 
                                        //if not make it lowercase or lead with an underscore
        public Person()
        {
            Name = string.Empty;
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"[{Id}]  {Name}";
        }
    }
}