using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;

namespace Library.LearningManagement.Services
{
    public class CourseService // so we can access it in the helper
    {
        private List<Course> courseList;

        private static CourseService? _instance;

        private CourseService()
        {
            courseList = new List<Course>();
        }

        public static CourseService Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        public void Add(Course course)
        {
            courseList.Add(course);
        }

        public List<Course> Courses //no setter because we dont someone to be ale to come in here and say new student serice
        {
            get
            {
                return courseList;
            }
        }

        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s=> s.Name.ToUpper().Contains(query.ToUpper())
                    || s.Description.ToUpper().Contains(query.ToUpper())
                    || s.Code.ToUpper().Contains(query.ToUpper()));
                
        }
    }


}