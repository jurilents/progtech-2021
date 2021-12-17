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
			return this.Ok(new { Success = true, Version = "Server_3", Info = new { Name = "yurii" } });
		}
	}
}