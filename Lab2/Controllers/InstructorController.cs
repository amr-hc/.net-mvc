using Lab2.Models;
using Lab2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class InstructorController : Controller
    {
        public Mydb db = new Mydb();


        [HttpGet]
        public IActionResult Index()
        {
            List<Instructor> instructors = db.Instructors.Include(i=>i.course).Include(i => i.department).ToList();
            return View("index", instructors);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            InstructorDetailsViewModel instructorDetailsViewModel = new InstructorDetailsViewModel();
            instructorDetailsViewModel.Instructor = db.Instructors.Include(i => i.course).Include(i => i.department).FirstOrDefault(i=>i.id == id);
            return View("details", instructorDetailsViewModel);
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            InstructorDetailsViewModel instructorDetailsViewModel = new InstructorDetailsViewModel();
            instructorDetailsViewModel.Instructor = db.Instructors.Include(i => i.course).Include(i => i.department).FirstOrDefault(i => i.id == id);
            instructorDetailsViewModel.departmentlist = db.Departments.ToList();
            instructorDetailsViewModel.courseslist = db.Courses.ToList();
            return View("edit", instructorDetailsViewModel);

        }

        [HttpPost]
        public IActionResult saveedit(InstructorDetailsViewModel instructorDetailsViewModel, int id)
        {
            Instructor instructor = db.Instructors.FirstOrDefault(i => i.id == id);
            instructor.name = instructorDetailsViewModel.Instructor.name;
            instructor.salary = instructorDetailsViewModel.Instructor.salary;
            instructor.dept_id = instructorDetailsViewModel.Instructor.dept_id;
            instructor.crs_id = instructorDetailsViewModel.Instructor.crs_id;
            db.SaveChanges();
            return RedirectToAction("index");

        }


        [HttpGet]
        public IActionResult add() {
            InstructorDetailsViewModel instructorDetailsViewModel = new InstructorDetailsViewModel();
            instructorDetailsViewModel.departmentlist = db.Departments.ToList();
            instructorDetailsViewModel.courseslist = db.Courses.ToList();
            return View("add", instructorDetailsViewModel);
        }


        public IActionResult savecreate(Instructor instructor)
        {
            db.Instructors.Add(instructor);
            db.SaveChanges();
            return RedirectToAction("index");
        }




    }
}
