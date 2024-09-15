using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }

        public int degree { get; set; }
        public int hours { get; set; }
        public int minDegree { get; set; }

        [ForeignKey("department")]
        public int dept_id { get; set; }
        public Department department { get; set; }

        public List<Instructor> instructors { get; set; }

        public List<CrsResult> crsResults { get; set; }



    }
}
