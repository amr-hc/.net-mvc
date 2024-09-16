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
            List<Course> courses = db.Courses.Skip(5*(page-1)).Take(50).ToList();

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
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.deprtments = db.Departments.ToList();
                return View("add", course);
            }
            

            
        }

        
        public IActionResult delete(int id)
        {
            Course course = db.Courses.FirstOrDefault(c => c.id == id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("index");
        }



        public IActionResult CheckminlessDegree(int degree, int minDegree)
        {
            if(degree > minDegree)
            {
                return Json(true);
            }

            return Json(false);
        }


        public IActionResult edit(int id)
        {
            Course course = db.Courses.FirstOrDefault(c => c.id == id);
            ViewBag.deprtments = db.Departments.ToList();

            return View("edit", course);
        }

        public IActionResult saveedit(Course editedCourse, int id)
        {
            if (ModelState.IsValid)
            {

                Course existingCourse = db.Courses.FirstOrDefault(c => c.id == id);

                db.Entry(existingCourse).CurrentValues.SetValues(editedCourse);

                db.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                ViewBag.deprtments = db.Departments.ToList();
                return View("edit", editedCourse);

            }

        }
    }
}
