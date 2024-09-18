using Lab2.Models;
using Lab2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class TraineeController : Controller
    {
        public Mydb db;

        public TraineeController(Mydb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowResult(int id,int crs_id)
        {
            CrsResult? CrsResult = db.CrsResults.Include(c=>c.course).Include(c=>c.trainee)
                .FirstOrDefault(c => c.trainee_id == id && c.crs_id == crs_id);

            ResultUserViewMode model = new ResultUserViewMode();
            model.TranneName = CrsResult.trainee.name;
            model.CourseName = CrsResult.course.name;
            model.Degree = CrsResult.degree;

            if(model.Degree >= CrsResult.course.minDegree)
            {
                model.color = "green";
                model.status = "success";
            }
            else
            {
                model.color = "red";
                model.status = "failed";

            }


            return View("showresult", model);
        }
    }
}
