using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ReplyFlow.Features.Auth.Factory;
using ReplyFlow.Features.Auth.ViewModels;
using ReplyFlow.Shared.Exceptions;
using System.Security.Claims;

namespace ReplyFlow.Features.Auth.EndPoints
{

    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("account/register")]
        public IActionResult Register()
        {
            return View(
                "~/Features/Auth/Views/Register.cshtml",
                new RegisterViewModel());
        }

        [HttpPost("account/register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(
                    "~/Features/Auth/Views/Register.cshtml",
                    model);
            }
            
            try
            {
                var command = RegisterFactory.CreateCommand(model);

                await _mediator.Send(command);

                return RedirectToAction(nameof(RegisterSuccess));
            }
            catch (DuplicatePhoneNumberException ex)
            {
                ModelState.AddModelError(
                    nameof(model.PhoneNumber),
                    ex.Message);

                return View(
                    "~/Features/Auth/Views/Register.cshtml",
                    model);
            }
        }

        [HttpGet("account/success")]
        public IActionResult RegisterSuccess()
        {
            return View(
                "~/Features/Auth/Views/RegisterSuccess.cshtml");
        }

        [HttpGet("account/login")]
        public IActionResult Login()
        {
            return View(
                "~/Features/Auth/Views/Login.cshtml");
        }

        [HttpPost("account/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(
                    "~/Features/Auth/Views/Login.cshtml",
                    model);
            }

            try
            {
                var command = LoginFactory.Create(model);

                var userId = await _mediator.Send(command);

                // Authentication Cookie
                var claims = new List<Claim>
                   {
                      new(ClaimTypes.NameIdentifier, userId.ToString())
                   };
                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                  principal,new AuthenticationProperties
                {
                  IsPersistent = model.RememberMe
                });
                //in future return views
                //return RedirectToAction("/");
                return Content("Login Successful");
            }
            catch (InvalidLoginException ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    ex.Message);

                return View(
                    "~/Features/Auth/Views/Login.cshtml",
                    model);
            }
        }

        //infuture put it in layout
        [HttpPost("account/logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login));
        }
    }
}
