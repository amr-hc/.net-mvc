using Lab2.Migrations;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class CourseController : Controller
    {
        public Mydb db = new Mydb();

        //[HttpGet]
        //public IActionResult Index(string search)
        //{


        //    List<Course> courses;
        //    if (search == null)
        //    {
        //        courses = db.Courses.ToList();
        //    }
        //    else
        //    {

        //        courses = db.Courses.Where(c => c.name.ToLower().Contains(search.ToLower())).ToList();
        //    }

        //    return View("index", courses);
        //}


        [HttpGet]
        public IActionResult Index(string search,int page)
        {
            if(page <= 0) {
                page = 1;
            }
            List<Course> courses = db.Courses.Skip(5*(page-1)).Take(5).ToList();

            return View("index", courses);
        }


        [HttpGet]
        public IActionResult add()
        {
            ViewBag.deprtments = db.Departments.ToList();
            return View("add");
        }

        [HttpPost]
        public IActionResult saveadd(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        
        public IActionResult delete(int id)
        {
            Course course = db.Courses.FirstOrDefault(c => c.id == id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
