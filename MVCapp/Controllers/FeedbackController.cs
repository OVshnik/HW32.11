using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApp.Models.Db;
using MVCapp.Models;
using MVCapp.Models.Db;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MVCapp.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId =
                Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
