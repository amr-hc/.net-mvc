using Microsoft.EntityFrameworkCore;

namespace Lab2.Models
{
    public class Mydb:DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Trainee> Trainees { get; set; }




        public Mydb() : base()
        {

        }


        public Mydb(DbContextOptions Options) : base(Options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=labtwodotnet;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }




    }
}
