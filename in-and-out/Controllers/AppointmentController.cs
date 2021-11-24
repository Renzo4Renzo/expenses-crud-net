using Microsoft.AspNetCore.Mvc;


namespace in_and_out.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return Ok("You have entered id = "+ id);
        }
    }
}
 