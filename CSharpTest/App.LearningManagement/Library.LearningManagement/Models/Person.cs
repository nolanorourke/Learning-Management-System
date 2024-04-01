namespace Library.LearningManagement.Models
{
    public class Person
    {
        public int Id {get; set;}
        public string Name{get; set;} //if it is public should be captial, 
                                        //if not make it lowercase or lead with an underscore
        
        
        public Person()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"[{Id}]  {Name}";
        }
  
    }
}