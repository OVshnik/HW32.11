using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCapp.Models.Db.Entity;
using MVCapp.Models.Db.Repository;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MVCapp.Controllers
{
    public class UsersController:Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }
        public async Task <IActionResult> Index()
        {
            var authors = await _repo.GetUsers();

            return View(authors);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
