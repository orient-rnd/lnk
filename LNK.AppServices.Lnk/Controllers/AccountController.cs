using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNK.Infrastructure.Queries;
using LNK.Infrastructure.Commands;
using AutoMapper;
using LNK.Domain.Users.Services;
using LNK.Domain.Emails.Services;
using LNK.AppServices.Lnk.Models.Account;
using System.Net;
using LNK.Commands.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using LNK.Domain.Users.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LNK.AppServices.Lnk.Controllers
{
    public class AccountController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly ICommandHandler<UpdateUserCommand> _commandHandler;

        public AccountController(
            IQueryBus queryBus,
            ICommandBus commandBus,
            IMapper mapper,
            IUserService userService,
            IEmailService emailService,
            ICommandHandler<UpdateUserCommand> commandHandler)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
            _userService = userService;
            _emailService = emailService;
            _commandHandler = commandHandler;
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPassword(ForgotPasswordModel model)
        {
            ViewBag.temp = true;
            string newPassword = "Huycautac1995";//default password
            var user =  _userService.FindByEmailAsync(model.UserName).Result;
            if (user != null)
            { 
                var token =  _userService.GeneratePasswordResetTokenAsync(user).Result;
                var result = _userService.ResetPasswordAsync(user, token, newPassword).Result;
                ModelState.AddModelError("Email", "We had sent a request to your email to change your password. Please check it!");
            }
            else
            {
                ModelState.AddModelError("Email", "We had sent a request to your email to change your password. Please check it!");
                return View(model);
            }
            
            
            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Vocabularies");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {           
            var user = _userService.FindByEmailAsync(User.Identity.Name).Result;
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User com)
        {
            var user = _mapper.Map<User, UpdateUserCommand>(com);
            _commandHandler.Handle(user);
            return View(com);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var cp = new ChangePasswordModel();
            return View(cp);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel cp)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.FindByEmailAsync(User.Identity.Name).Result;
                if (user != null)
                {
                    var change = _userService.ChangePasswordAsync(user, cp.CurrentPassword, cp.NewPassword).Result;
                    if (change.Succeeded)
                    {
                        cp.ChangePasswordSuccess = true;
                        ViewBag.Confirm = "Your password was changed successfully.";
                    }
                    else
                    {
                        ViewBag.Error = "Cannot change your password";
                    }
                }
            }

            return View(cp);
        }
    }
}
