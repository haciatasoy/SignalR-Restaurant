﻿using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(RegisterDto registerDto)
		{
			var appUser = new AppUser()
			{
				NameSurname = registerDto.NameSurname,
				Email = registerDto.Mail,
				UserName = registerDto.Username
			};
			var result = await _userManager.CreateAsync(appUser, registerDto.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
	}
}
