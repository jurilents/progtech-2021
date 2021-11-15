using System;
using System.Collections.Generic;
using System.Linq;
using ElementarySchool.Core.Exceptions;
using ElementarySchool.Models;
using ElementarySchool.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace ElementarySchool.Controllers
{
	[ApiController]
	[Route("/api/schools")]
	public class SchoolsController : ControllerBase
	{
		private readonly ILogger<SchoolsController> _logger;
		private readonly ISchoolRepository _schoolRepository;
		private readonly IClassManager _classManager;

		public SchoolsController(ILogger<SchoolsController> logger, ISchoolRepository schoolRepository, IClassManager classManager)
		{
			_logger = logger;
			_schoolRepository = schoolRepository;
			_classManager = classManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<School>> All()
		{
			return _schoolRepository.GetAll().ToList();
		}


		[HttpPost("{name:alpha}/kids-random")]
		public IActionResult AddKids(string name, int count = 1)
		{
			try
			{
				_classManager.AddKidsRandom(name, count);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Random kids not added due to an error");
				return StatusCode(500);
			}

			return Ok();
		}

		[HttpPost("{name:alpha}/kids")]
		public IActionResult AddKids(string name, IEnumerable<Child> children)
		{
			try
			{
				_classManager.AddKids(name, children);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Kids not added due to an error");
				return StatusCode(500);
			}

			return Ok();
		}

		[HttpPost]
		public ActionResult<School> Create(string name)
		{
			if (_schoolRepository.GetByName(name) is not null)
				return BadRequest();

			try
			{
				var school = SchoolFactory.Create(name);
				_schoolRepository.Create(school);
				return school;
			}
			catch (HttpException e)
			{
				return BadRequest(new ModelError(e));
			}
		}

		[HttpDelete]
		public IActionResult Delete(string name)
		{
			var school = _schoolRepository.GetByName(name);

			if (school is null)
				return NotFound();

			_schoolRepository.Delete(school);
			return Ok();
		}
	}
}