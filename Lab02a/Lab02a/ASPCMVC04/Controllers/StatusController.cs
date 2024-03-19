using Microsoft.AspNetCore.Mvc;
using System;

namespace ASPCMVC04.Controllers
{
    public class StatusController : Controller
    {
        private readonly Random random = new Random();
        public IActionResult S200()
        {
            return StatusCode(random.Next(200, 300));
        }

        public IActionResult S300()
        {
            return StatusCode(random.Next(300, 400));
        }

        public IActionResult S500()
        {
            try
            {
                int x = 5, y = 0;
                int result = x / y;
                return View();
            }
            catch (DivideByZeroException ex)
            {
                return StatusCode(random.Next(500, 600));
            }
        }
    }
}
