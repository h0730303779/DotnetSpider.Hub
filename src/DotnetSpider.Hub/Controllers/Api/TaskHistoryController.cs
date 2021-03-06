﻿using DotnetSpider.Hub.Application.TaskHistory;
using DotnetSpider.Hub.Core;
using DotnetSpider.Hub.Core.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace DotnetSpider.Hub.Controllers.Api
{
	[Route("api/v1.0/[controller]")]
	public class TaskHistoryController : BaseController
	{
		private readonly ITaskHistoryAppService _taskHistoryAppService;


		public TaskHistoryController(ITaskHistoryAppService taskHistoryAppService, IAppSession appSession, ICommonConfiguration commonConfiguration) : base(appSession, commonConfiguration)
		{
			_taskHistoryAppService = taskHistoryAppService;
		}

		[HttpGet]
		public IActionResult Find(PaginationQueryInput input)
		{
			return Success(_taskHistoryAppService.Find(input));
		}
	}
}
