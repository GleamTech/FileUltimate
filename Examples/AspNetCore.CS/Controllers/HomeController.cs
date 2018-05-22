using Microsoft.AspNetCore.Mvc;

namespace GleamTech.FileUltimateExamples.AspNetCore.CS.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
