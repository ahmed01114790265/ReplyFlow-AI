using Microsoft.AspNetCore.Mvc;
using ReplyFlow.Features.Leads.ViewModels;
using MediatR;
using ReplyFlow.Features.Leads.Factory;
namespace ReplyFlow.Features.Leads.EndPoints
{

    public class LeadsController : Controller
    {
        private readonly IMediator _mediator;
        public LeadsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/leads/create")]
        public IActionResult Create()
        {
            return View(
                "~/Features/Leads/Views/Create.cshtml",
                new CreateLeadViewModel());
        }

        [HttpPost("/leads/create")]
        public async Task<IActionResult> Create(CreateLeadViewModel model)
        {
            if (!ModelState.IsValid)
                return View(
                    "~/Features/Leads/Views/Create.cshtml",
                    model);

            var command = LeadFactory.CreateCommandLead(model);

            await _mediator.Send(command);

            return RedirectToAction(nameof(Success));
        }

        [HttpGet("/leads/success")]
        public IActionResult Success()
        {
            return View(
                "~/Features/Leads/Views/Success.cshtml");
        }
    }
}
