using Lab2.Migrations;
using Lab2.Models;
using Lab2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class CourseController : Controller
    {

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
        ICourseRepository CourseRepo;
        IDepartmentRepository DepartmentRepo;
        public CourseController(ICourseRepository CourseRepo, IDepartmentRepository DepartmentRepo)
        {
            this.CourseRepo = CourseRepo;
            this.DepartmentRepo = DepartmentRepo;
        }



        [HttpGet]
        [Authorize]
        public IActionResult Index(string search,int page)
        {
            if(page <= 0) {
                page = 1;
            }
            //List<Course> courses = db.Courses.Skip(5*(page-1)).Take(50).ToList();

            List<Course> courses = CourseRepo.GetAll();

            return View("index", courses);
        }


        [HttpGet]
        public IActionResult add()
        {
            //ViewBag.deprtments = db.Departments.ToList();
            ViewBag.deprtments = DepartmentRepo.GetAll();
            return View("add");
        }

        [HttpPost]
        public IActionResult saveadd(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepo.Add(course);
                CourseRepo.Save();
                return RedirectToAction("index");
            }
            else
            {
                //ViewBag.deprtments = db.Departments.ToList();
                ViewBag.deprtments = DepartmentRepo.GetAll();
                return View("add", course);
            }
            

            
        }

        
        public IActionResult delete(int id)
        {
            //Course course = db.Courses.FirstOrDefault(c => c.id == id);
            //Course course = db.Courses.FirstOrDefault(c => c.id == id);
            // db.Courses.Remove(course);
            //db.SaveChanges();

            CourseRepo.Delete(id);
            CourseRepo.Save();
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
            //Course course = db.Courses.FirstOrDefault(c => c.id == id);
            Course course = CourseRepo.Getbyid(id);
            //ViewBag.deprtments = db.Departments.ToList();
            ViewBag.deprtments = DepartmentRepo.GetAll();

            return View("edit", course);
        }

        public IActionResult saveedit(Course editedCourse, int id)
        {
            if (ModelState.IsValid)
            {

                //Course existingCourse = db.Courses.FirstOrDefault(c => c.id == id);

                //db.Entry(existingCourse).CurrentValues.SetValues(editedCourse);

                //db.SaveChanges();
                editedCourse.id = id;
                CourseRepo.Update(editedCourse);
                CourseRepo.Save();

                return RedirectToAction("index");
            }
            else
            {
                ViewBag.deprtments = DepartmentRepo.GetAll();
                return View("edit", editedCourse);

            }

        }


        [HttpGet]
        public IActionResult GetCoursesbyDepId(int id) {

            return Json(CourseRepo.GetCoursesByDeprtID(id));
        }
    }
}
