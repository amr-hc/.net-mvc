using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private Mydb db;
        public CourseRepository(Mydb db) {
            this.db = db;
        }
        public void Add(Course obj)
        {
            db.Add(obj);
        }
        public void Update(Course obj)
        {
            db.Update(obj);
        }
        public void Delete(int id)
        {
            Course course = this.Getbyid(id);
            db.Courses.Remove(course);
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }    
        public List<Course> GetCoursesByDeprtID(int id)
        {
            return db.Courses.Where(c=>c.dept_id==id).ToList();
        }
        public Course Getbyid(int id)
        {
            return db.Courses.SingleOrDefault(c => c.id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
