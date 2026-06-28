using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReplyFlow.Features.Auth.Factory;
using ReplyFlow.Features.Auth.ViewModels;
using ReplyFlow.Shared.Exceptions;

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
    }
}
