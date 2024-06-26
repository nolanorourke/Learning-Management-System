using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;

namespace Library.LearningManagement.Services
{
    public class StudentService // so we can access it in the helper
    {
        private List<Person> studentList;

        private static StudentService? _instance;

        private StudentService()
        {
            studentList = new List<Person>();
        }

        public static StudentService Current
        {
            get
            {
                if(_instance == null)
                    _instance = new StudentService();
                return _instance;
            }
        }

        
        public void Add(Person student)
        {
            studentList.Add(student);
        }

        public List<Person> Students //no setter because we dont someone to be ale to come in here and say new student serice
        {
            get
            {
                return studentList;
            }
        }

        public IEnumerable<Person> Search(string query)
        {
            return studentList.Where(s=> s.Name.ToUpper().Contains(query.ToUpper())); 
        }
    }


}