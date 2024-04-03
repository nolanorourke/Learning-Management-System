using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class Course
    {
        public string Code
        {
            get
            {
                return $"{Prefix} {Id}";
            }
        }
        public int Id {get; private set;}

        public string Prefix{get; set;}
        private static int lastId=0;

        public string Name{get;set;}

        public string Description{get;set;}

        public List<Person> Roster{ get; set;}

        public List<AssignmentGroup> AssignmentGroups{get; set;}
        public IEnumerable<Assignment> Assignments
        {
            get
            {
                return AssignmentGroups.SelectMany(ag => ag.Assignments);
            }
        }
        public List<Submission> Submissions {get; set;} //made a list not an 
        //ienumerable because ienumerable are read access only and we have to 
        //change this eventually 

        public List<Module> Modules{get; set;}

        public List<Announcement> Announcements{get;set;}

        public int CreditHours{get;set;}
        public Course()
        {
            Name = string.Empty;
            Description = string.Empty;
            Roster = new List<Person>();
            AssignmentGroups = new List<AssignmentGroup>();
            Submissions = new List<Submission>();
            Modules = new List<Module>();
            Announcements = new List<Announcement>();
            Prefix = string.Empty;
            Id = ++lastId;
            CreditHours = 3;
        }
        // public Course(string? c, string? n, string? d, List<Person> r, List<Assignment> a, List<Module> m)
        // {
        //     Code = c;
        //     Name = n;
        //     Description = d;
        //     Roster = r;
        //     Assignments = a;
        //     Modules = m;
        // }
        // public Course(string? c, string? n, string? d)
        // {
        //     Code = c;
        //     Name = n;
        //     Description = d;
        // }
        public override string ToString()
        {
            return $"({Code}) - {Name}";
        }

        public string DetailDisplay
        {
            get
            {
                return $"{ToString()}\n{Description}\n\n" +
                    $"Announcements {string.Join("\n\t", Announcements.Select(s => s.ToString()).ToArray())}\n\n""
                    $"Roster:\n{string.Join("\n\t", Roster.Select(s => s.ToString()).ToArray())}\n\n" +
                    $"Assignments:\n{string.Join("\n\t", AssignmentGroups.Select(a => a.ToString()).ToArray())}\n\n"+
                    $"Modules:\n{string.Join("\n\t", Modules.Select(m => m.ToString()).ToArray())}";
                    
            }
        }
    }
}