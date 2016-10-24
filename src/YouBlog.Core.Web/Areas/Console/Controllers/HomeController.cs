using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YouBlog.Core.Web.Areas.Console.Controllers
{
    [Area("Console")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}