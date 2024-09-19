using Lab2.Migrations;
using Lab2.Models;
using Lab2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class InstructorController : Controller
    {
        public Mydb db;

        public InstructorController(Mydb db)
        {
            this.db = db;
        }
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


        public IActionResult savecreate(Instructor instructor, IFormFile photo)
        {

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Create a unique file name for the uploaded image
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

            // Get the file path to save the image
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save the uploaded image to the server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            // Save the file path to the Course object (adjust the property if necessary)
            instructor.image = "/uploads/" + uniqueFileName;



            db.Instructors.Add(instructor);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        




    }
}
