using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Trainee
    {

        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        public string address { get; set; }

        public int grade { get; set; }

        [ForeignKey("department")]
        public int dept_id { get; set; }

        public Department department { get; set; }

        public List<CrsResult> crsResults { get; set; }


    }
}
