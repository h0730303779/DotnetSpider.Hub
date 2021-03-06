﻿using System.Linq;
using DotnetSpider.Hub.Core;
using DotnetSpider.Hub.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DotnetSpider.Hub.Application
{
	public static class UserManagerExtensions
	{
		public static bool CheckPermission(this UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor, string claimName, bool throwException = true)
		{
			var hasClaim = HasClaim(accessor, claimName);
			if (throwException)
			{
				if (!hasClaim)
				{
					throw new DotnetSpiderException($"Permission \"{claimName}\" required. Please contact admin.");
				}
			}
			return hasClaim;
		}

		public static ApplicationUser GetUserById(this UserManager<ApplicationUser> userManager, long id)
		{
			return userManager.Users.FirstOrDefault(u => u.Id == id);
		}

		public static bool HasClaim(IHttpContextAccessor accessor, string claimName)
		{
			return accessor.HttpContext.User.Claims.Any(c => c.Value == claimName);
		}

	}
}
