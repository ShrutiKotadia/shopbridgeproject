using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkBridgeSoft.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult Index()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exception != null && exception.Error != null)
                ViewBag.ErrorDetails = exception.Error.ToString();
            else
                ViewBag.ErrorDetails = "";
            return View("~/Views/Error/Error.cshtml");
        }
    }
}
