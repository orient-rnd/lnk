using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Infrastructure.Commands;
using AutoMapper;
using BomBiEn.Domain.Users.Services;
using BomBiEn.Domain.Emails.Services;
using BomBiEn.AppServices.Lnk.Models.Account;
using System.Net;
using BomBiEn.Commands.Users;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BomBiEn.AppServices.Lnk.Controllers
{
    public class AccountController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AccountController(
            IQueryBus queryBus,
            ICommandBus commandBus,
            IMapper mapper,
            IUserService userService,
            IEmailService emailService)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
            _userService = userService;
            _emailService = emailService;
        }


        public ActionResult Register()
        {
            if (User.Identity.Name != null)
            {
                RedirectToAction("Index", "Home");
            }
            var userResponse = new UserResponseModel() { Status = Shared.Enums.UserStatus.Rejected };
            ViewBag.response = userResponse;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(LoginModel request)
        {
            var signUpCommand = new SignUpCommand() { Email = request.UserName, Password = request.Password };
            _commandBus.Send(signUpCommand);

            var userResponse = new UserResponseModel() { Status = Shared.Enums.UserStatus.Approved };
            var result = await _userService.SignInAsync(request.UserName, request.Password, true);
            if (result.Succeeded)
            {
                userResponse.Status = Shared.Enums.UserStatus.Approved;
            }
            else
            {
                userResponse.Status = Shared.Enums.UserStatus.Rejected;
            }
            ViewBag.response = userResponse;
            return View();
        }


        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var returnUrl = Request.Query["returnUrl"];
            returnUrl = WebUtility.UrlDecode(returnUrl);

            if (String.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var result = await _userService.SignInAsync(model.UserName, model.Password, model.RememberMe);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("UserName", "Account is locked out.");
                        return View(model);
                    }

                    if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("UserName", "Account is not allowed.");
                        return View(model);
                    }

                    if (result.RequiresTwoFactor)
                    {
                        ModelState.AddModelError("UserName", "Account requires two factor.");
                        return View(model);
                    }

                    ModelState.AddModelError("UserName", "User name or password incorrect.");
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Vocabularies");
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}
