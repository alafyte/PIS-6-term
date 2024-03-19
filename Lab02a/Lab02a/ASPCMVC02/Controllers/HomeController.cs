using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("http://localhost:5200/index.html");
        }
    }
}
