using Microsoft.AspNetCore.Mvc;

namespace ASPCMVC07.Controllers
{
    [Route("it")]
    public class TAResearch : Controller
    {
        [HttpGet]
        [Route("{n:int}/{str}", Order = 1)]
        public string M04(int n, string str) => $"GET:M04: /{n}/{str}";


        [AcceptVerbs("GET", "POST")]
        [Route("{b:bool}/{letters:alpha}")]
        public string M05(bool b, string letters) => $"{HttpContext.Request.Method}:M05: /{b}/{letters}";


        [AcceptVerbs("GET", "DELETE")]
        [Route("{f:float}/{str:length(2,5)}", Order = 2)]
        public string M06(float f, string str) => $"{HttpContext.Request.Method}:M06: /{f}/{str}";


        [HttpPut]
        [Route("{letters:alpha:length(3,4)}/{n:int:range(100,200)}")]
        public string M07(string letters, int n) => $"PUT:M07: /{letters}/{n}";


        [HttpPost]
        [Route("{mail:regex(^\\w+@\\w+\\.\\w+)}")]
        public string M08(string mail) => $"POST:M08/{mail}";


    }
}
