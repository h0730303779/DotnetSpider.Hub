﻿using DotnetSpider.Hub.Core;
using DotnetSpider.Hub.Core.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace DotnetSpider.Hub.Controllers
{
	public class RunningTaskController : BaseController
	{
		public RunningTaskController(IAppSession appSession, ICommonConfiguration commonConfiguration) : base(appSession, commonConfiguration)
		{
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
