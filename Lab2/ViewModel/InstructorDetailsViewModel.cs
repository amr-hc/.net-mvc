using Lab2.Models;

namespace Lab2.ViewModel
{
    public class InstructorDetailsViewModel
    {
        public Instructor Instructor { get; set; }

        public List<Department> departmentlist { get; set; }
        public List<Course> courseslist { get; set; }
        
    }
}
