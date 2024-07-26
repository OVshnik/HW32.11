using Microsoft.AspNetCore.Mvc;
using MVCapp.Models.Db.Entity;
using MVCapp.Models.Db.Repository;
using System.Threading.Tasks;

namespace MVCapp.Controllers
{
	public class LogsController:Controller
	{
		

		private readonly ILogRepository _repo;

		public LogsController(ILogRepository repo)
		{
			_repo = repo;
		}
		public async Task<IActionResult> Index()
		{
			var requests = await _repo.GetRequests();

			return View(requests);
		}
	}
}
