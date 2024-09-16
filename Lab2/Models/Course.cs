using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Course
    {
        public int id { get; set; }

        [UniqeName]
        public string name { get; set; }

        [Range(50,100)]

        [Remote(action: "CheckminlessDegree",controller:"Course",AdditionalFields = "minDegree", ErrorMessage = "degree must be greater than minDegree")]
        public int degree { get; set; }
        public int hours { get; set; }

        [Range(20, 60)]
        public int minDegree { get; set; }

        [ForeignKey("department")]
        public int dept_id { get; set; }
        public Department? department { get; set; }

        public List<Instructor>? instructors { get; set; }

        public List<CrsResult>? crsResults { get; set; }



    }
}
