using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElementarySchool.Controllers
{
	[ApiController]
	[Route("/")]
	public class HomeController : ControllerBase
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public ActionResult Get()
		{
			return this.Ok(new { Success = true, Version = "Server_2.0", Data = new[] { "yurii", "practice 3 / server 2" } });
		}
	}
}