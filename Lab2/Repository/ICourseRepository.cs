using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Repository
{
    public interface ICourseRepository 
    {
        public void Add(Course obj);
        public void Update(Course obj);
        public void Delete(int id);

        public List<Course> GetAll();

        public List<Course> GetCoursesByDeprtID(int id);
        public Course Getbyid(int id);
        public void Save();
    }
}
