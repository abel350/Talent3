using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Talento.Controllers
{
    [Route("CoreUI")]
    public class TalentController : Controller
    {
        [Route("{view=Index}")]
        public IActionResult Index(string view)
        {
            ViewData["Title"] = "Páginas de Talent";
            return View(view);
        }
    }
}

