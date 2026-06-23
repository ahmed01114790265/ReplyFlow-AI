using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReplyFlow.Features.Leads.Comman.Mapping;

namespace ReplyFlow.Features.Leads.CreateLead
{
    public class LeadController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBusinessTypeFactory _factory;

        //for views
        private const string ViewPath = "/Features/Leads/CreateLead/Create.cshtml";
        private const string SuccessViewPath = "/Features/Leads/CreateLead/Success.cshtml";
        public LeadController(IMediator mediator, IBusinessTypeFactory factory)
        {
            _mediator = mediator;
            _factory = factory;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BusinessTypes = _factory.Create();
            return View(ViewPath, new CreateLeadViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLeadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BusinessTypes = _factory.Create();
                return View(ViewPath, model);
            }

            var leadId = await _mediator.Send(
                new CreateLeadCommand(
                    model.Name,
                    model.Phone,
                    model.BusinessType));

            return RedirectToAction("Success");
        }
        [HttpGet]
        public IActionResult Success()
        {
            return View(SuccessViewPath);
        }

    }
}
