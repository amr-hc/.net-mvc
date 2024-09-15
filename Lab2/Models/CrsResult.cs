using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class CrsResult
    {
        public int id { get; set; }

        public decimal degree { get; set; }


        [ForeignKey("course")]
        public int crs_id { get; set; }


        [ForeignKey("trainee")]
        public int trainee_id { get; set; }

        public Course course { get; set; }
        public Trainee trainee { get; set; }
    }
}
