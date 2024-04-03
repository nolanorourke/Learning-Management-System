//in main we have to know that studnt help exists, we have a lot of options for how to build this class

//not an internal, but a public class, we create an instance of it in the main function, 
//and anytime we have to do anything with it in main we will delegate the work to the helper

//without helpers, you will be stranded with a menu inside of a menu inside of a menu etc and there will be tons of references inside of the program
// takes away from encapsulation which is something we apparently fuck with here

using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using Microsoft.VisualBasic;
using Nolanvas;

namespace App.LearningManagement.Helpers
{
    internal class StudentHelper //when you make it static, it can only use static variables, then you would have to make all of the functions static, 
    //anytiem someone makes an object for this class, it will load all of the functions inside of it
    //worst case scenario that in program i will have to maintain this instance of StudentHelper, big whup
    {

        private StudentService studentService;
        private CourseService courseService;
        private ListNavigator<Person> studentNavigator;
        public StudentHelper()
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;

            studentNavigator = new ListNavigator<Person>(studentService.Students, 2);
        }

        public void AddStudent(Person? selectedStudent = null)
        {
            bool isCreate = false;
            if(selectedStudent == null)
            {
                isCreate = true;
                Console.WriteLine("What kind of person would you like to add: ");
                Console.WriteLine("(S)tudent");
                Console.WriteLine("(T)eaching Assistant");
                Console.WriteLine("(I)nstructor");
                var choice = Console.ReadLine() ?? string.Empty;
                if(!string.IsNullOrEmpty(choice))
                    return;
                
                if(choice.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                    selectedStudent = new Student();
                else if(choice.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                    selectedStudent = new TeachingAssistant();
                else if(choice.Equals("I", StringComparison.InvariantCultureIgnoreCase))
                    selectedStudent = new Instructor();

                else
                {
                    Console.WriteLine("Invalid Entry");
                    return;
                }
                
            }


            // Console.WriteLine("Person ID: ");
            // var studID = Console.ReadLine();
            Console.WriteLine("Name:");
            var name = Console.ReadLine();
            if (selectedStudent is Student)
            {
                Console.WriteLine("Year in school[(F)reshman, S(O)phomore, (J)unior, (S)enior]: ");
                var year = Console.ReadLine() ?? string.Empty;
                PersonClassification classEnum = PersonClassification.Freshman;
                if(year.Equals("O", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = PersonClassification.Sophomore;
                }
                else if(year.Equals("J", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = PersonClassification.Junior;
                }
                else if(year.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = PersonClassification.Senior;
                }

                var studentRecord = selectedStudent as Student;

                if (studentRecord != null)
                {
                    studentRecord.Classification = classEnum;
                    //studentRecord.Id = int.Parse(studID ?? "0");
                    studentRecord.Name = name ?? string.Empty; 
                }
                

                if(isCreate)
                    studentService.Add(selectedStudent);
            }
            else 
            {
                if(selectedStudent != null)
                {
                    //selectedStudent.Id = int.Parse(studID ?? "0");
                    selectedStudent.Name = name ?? string.Empty; 
                    if(isCreate)
                        studentService.Add(selectedStudent);
                }
            }
        }
        public void UpdateStudent()
        {
            Console.WriteLine("Select a person to update: ");
            ListStudents();

            var selection = Console.ReadLine();
            var selectionInt = int.Parse(selection ?? "0");

            var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id ==selectionInt);
            if(selectedStudent != null)
            {
                AddStudent(selectedStudent);
            }
            
        }

        // public void DeleteStudent()
        // {
        //     int count = 0;
        //     StudentService.Current.Students.ToList().ForEach( c => Console.WriteLine($"{++count}. {c}"));

        //     Console.WriteLine("Enter student index to update: ");
        //     var choice = Console.ReadLine();
        //     if(int.TryParse(choice, out int intChoice))
        //     {
        //         var studentToDelete = StudentService.Current.Students.ElementAt(intChoice-1);
        //         studentService.Delete(studentToDelete);
        //     }
        // }

        private void NavigateStudents(string query = null)
        {
            ListNavigator<Person>? currentNavigator = null;
            if(query == null)
                currentNavigator = studentNavigator;

            else
                currentNavigator = new ListNavigator<Person>(studentService.Search(query).ToList(),2);
            bool keepPaging = true;
            while(keepPaging)
            {
                foreach( var pair in studentNavigator.GetCurrentPage())
                Console.WriteLine($"{pair.Key}.  {pair.Value}");

                if(currentNavigator.HasPreviousPage)
                    Console.WriteLine("P. Previous Page");

                if(currentNavigator.HasNextPage)
                    Console.WriteLine("N. Next Page");

                Console.WriteLine("Make a selection: ");
                var selectionStr = Console.ReadLine();
                

                if((selectionStr?.Equals("P", StringComparison.InvariantCultureIgnoreCase) ?? false)
                    || (selectionStr?.Equals("N", StringComparison.InvariantCultureIgnoreCase) ?? false))
                {
                    if(selectionStr.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                        currentNavigator.GoBackward();
                        
                    
                    else if (selectionStr.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                        currentNavigator.GoForward();

                }
                else
                {
                    var selectionInt = int.Parse(selectionStr ?? "0");
                    Console.WriteLine("Student Course List: ");
                    courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
                    keepPaging = false;
                }
            }
        }
        public void ListStudents()
        {
            studentService.Students.Where(s => s is Student).ToList();
        }

        public void ListStudentCourses()
        {
            NavigateStudents();
        }



        public void SearchStudents()
        {
            Console.WriteLine("Enter a query: ");
            var query = Console.ReadLine() ?? string.Empty;

            // studentService.Search(query).ToList().ForEach(Console.WriteLine);
            // var selectionStr = Console.ReadLine();
            // var selectionInt = int.Parse(selectionStr ?? "0");

            // Console.WriteLine("Student Course List: ");
            // courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
            NavigateStudents(query);
        }

        public void GetGPA()
        {
            Console.WriteLine("Choose a student: ");
            studentService.Students.Where(s => s is Student).ToList();
            var selectedStudentId = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine($"GPA: {studentService.GetGPA(selectedStudentId)}");
        }
    }

}



