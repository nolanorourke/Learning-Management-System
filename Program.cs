using App.LearningManagement.Helpers;

namespace Nolanvas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ? input = "z";
            var studentHlpr = new StudentHelper();
            var courseHlpr = new CourseHelper();
            do
            {
                if(char.TryParse(input, out char result))
                {
                    DisplayMenu();
                    input = Console.ReadLine();
                    switch(input)
                    {
                        case "a":
                        case "A":
                            showStudentMenu(studentHlpr);
                        break;

                        case "b":
                        case "B":
                            showCourseMenu(courseHlpr);
                        break;

                        case "c":
                        case "C":
                            Console.WriteLine("Thank you for using Nolvas");
                        break;

                        default:
                            Console.WriteLine("Invalid input, try one of the letters A-C: ");
                        break;

                    }
                }
            }while(input.ToUpper() != "C");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Choose from the following options:");
            Console.WriteLine("A - Maintain People");
            Console.WriteLine("B - Maintain Courses");
            Console.WriteLine("C - Exit");
            Console.WriteLine("Enter your choice: ");
        }

        static void showStudentMenu(StudentHelper stuhlpr)
        {
            Console.WriteLine("A - Add a new person");
            Console.WriteLine("B - Update a person's information");
            Console.WriteLine("C - List all people");
            Console.WriteLine("D - Search for a person");
            Console.WriteLine("E - Remove a person");
            Console.WriteLine("F - List person's courses");

            var input = Console.ReadLine();
            if(char.TryParse(input, out char result))
            {
                switch(input)
                {
                        case "a":
                        case "A":
                            stuhlpr.AddStudent();
                        break;

                        case "b":
                        case "B":
                            stuhlpr.UpdateStudent();
                        break;

                        case "c":
                        case "C":
                            stuhlpr.ListStudents();
                        break;

                        case "d":
                        case "D":
                            stuhlpr.SearchStudents();
                        break;

                        case "e":
                        case "E":
                            
                        break;

                        case "f":
                        case "F":
                            stuhlpr.ListStudentCourses();
                        break;

                        default:
                            Console.WriteLine("Invalid input, try one of the letters A-E: ");
                        break;
                        
                }
            }
        }
        static void showCourseMenu(CourseHelper crshlpr)
        {
            Console.WriteLine("A - Create a Course and add it to a list of courses");
            Console.WriteLine("B - Update a course's information");
            Console.WriteLine("C - List all Courses");
            Console.WriteLine("D - Search for Courses by name or description");
            Console.WriteLine("E - Add a student to a course");
            Console.WriteLine("F - Remove a student from a course");
            Console.WriteLine("G - List all courses a student is taking");
            Console.WriteLine("H - Add an assignment");
            Console.WriteLine("I - Update an assignment");
            Console.WriteLine("J - Remove an assignment");
            Console.WriteLine("K - Add a module to a course");
            Console.WriteLine("L - Update a module");
            Console.WriteLine("M - Remove a module from a course");
            Console.WriteLine("N - Add an Announcement to a course");
            Console.WriteLine("O - Update an announcement for a course");
            Console.WriteLine("P - Remove an announcement from a course");
            Console.WriteLine("Q - Create a student Submission");


            var input = Console.ReadLine();
            if(char.TryParse(input, out char result))
            {
                switch(input)
                {
                        case "a":
                        case "A":
                            crshlpr.AddCourse();
                        break;

                        case "b":
                        case "B":
                            crshlpr.UpdateCourse();
                        break;

                        case "c":
                        case "C":
                            crshlpr.SearchCourses();
                        break;

                        case "d":
                        case "D":
                            Console.WriteLine("Enter a query: ");
                            var query = Console.ReadLine() ?? string.Empty;
                            crshlpr.SearchCourses(query);
                        break;

                        case "e":
                        case "E":
                            crshlpr.AddStudentToCourse();
                        break;

                        case "f":
                        case "F":
                            crshlpr.RemoveStudentFromCourse();
                        break;

                        case "g":
                        case "G":
                        break;

                        case "h":
                        case "H":
                            crshlpr.AddAssignment();
                        break;

                        case "i":
                        case "I":
                            crshlpr.UpdateAssignment();
                        break;

                        case "j":
                        case "J":
                            crshlpr.RemoveAssignment();
                        break;

                        case "k":
                        case "K":
                            crshlpr.AddModule();
                        break;

                        case "l":
                        case "L":
                            crshlpr.UpdateModule();
                        break;
                        case "m":
                        case "M":
                            crshlpr.RemoveModule();
                        break;
                        case "n":
                        case "N":
                            crshlpr.AddAnnouncement();
                        break;
                        case "o":
                        case "O":
                            crshlpr.UpdateAnnouncement();
                        break;
                        case "p":
                        case "P":
                            crshlpr.RemoveAnnouncement();
                        break;
                        case "q":
                        case "Q":
                            crshlpr.AddSubmission();
                        break;

                        default:
                            Console.WriteLine("Invalid input, try one of the letters A-O: ");
                        break;
                }
            }
        }
    }
}