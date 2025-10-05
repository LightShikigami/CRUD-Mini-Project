using Microsoft.AspNetCore.Mvc;

namespace CRUD_Mini_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
