using Microsoft.AspNetCore.Mvc;

namespace CoursePlus.API.Controllers
{
    public class ChoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
