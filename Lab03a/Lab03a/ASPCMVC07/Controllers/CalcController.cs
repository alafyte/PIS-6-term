using Microsoft.AspNetCore.Mvc;

namespace ASPCMVC07.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Calc");
        }

        [HttpGet]
        public IActionResult Sum()
        {
            ViewBag.press = "+";
            return View("Calc");
        }

        [HttpPost]
        public IActionResult Sum(string? x, string? y)
        {
            ViewBag.press = "+";
            if (float.TryParse(x, out float parsedX) && float.TryParse(y, out float parsedY))
            {
                if (float.IsInfinity(parsedX) || float.IsInfinity(parsedY))
                {
                    ViewBag.error = "Значения слишком большие";
                }
                else
                {
                    ViewBag.x = parsedX;
                    ViewBag.y = parsedY;
                    ViewBag.result = parsedX + parsedY;
                }
            }
            else
            {
                ViewBag.error = "Неверный формат параметров";
            }
            return View("Calc");
        }
        [HttpGet]
        public IActionResult Sub()
        {
            ViewBag.press = "-";
            return View("Calc");
        }

        [HttpPost]
        public IActionResult Sub(string? x, string? y)
        {
            ViewBag.press = "-";
            if (float.TryParse(x, out float parsedX) && float.TryParse(y, out float parsedY))
            {
                if (float.IsInfinity(parsedX) || float.IsInfinity(parsedY))
                {
                    ViewBag.error = "Значения слишком большие";
                }
                else
                {
                    ViewBag.x = parsedX;
                    ViewBag.y = parsedY;
                    ViewBag.result = parsedX - parsedY;
                }
            }
            else
            {
                ViewBag.error = "Неверный формат параметров";
            }
            return View("Calc");
        }
        [HttpGet]
        public IActionResult Mul()
        {
            ViewBag.press = "*";
            return View("Calc");
        }

        [HttpPost]
        public IActionResult Mul(string? x, string? y)
        {
            ViewBag.press = "*";
            if (float.TryParse(x, out float parsedX) && float.TryParse(y, out float parsedY))
            {
                if (float.IsInfinity(parsedX) || float.IsInfinity(parsedY))
                {
                    ViewBag.error = "Значения слишком большие";
                }
                else
                {
                    ViewBag.x = parsedX;
                    ViewBag.y = parsedY;
                    ViewBag.result = parsedX * parsedY;
                }
            }
            else
            {
                ViewBag.error = "Неверный формат параметров";
            }
            return View("Calc");
        }
        [HttpGet]
        public IActionResult Div()
        {
            ViewBag.press = "/";
            return View("Calc");
        }

        [HttpPost]
        public IActionResult Div(string? x, string? y)
        {
            ViewBag.press = "/";
            if (float.TryParse(x, out float parsedX) && float.TryParse(y, out float parsedY))
            {
                if (float.IsInfinity(parsedX) || float.IsInfinity(parsedY))
                {
                    ViewBag.error = "Значения слишком большие";
                } 
                else if (parsedY == 0)
                {
                    ViewBag.error = "Деление на 0 не допускается";
                }
                else
                {
                    ViewBag.x = parsedX;
                    ViewBag.y = parsedY;
                    ViewBag.result = parsedX / parsedY;
                }
            }
            else
            {
                ViewBag.error = "Неверный формат параметров";
            }
            return View("Calc");
        }
    }
}
