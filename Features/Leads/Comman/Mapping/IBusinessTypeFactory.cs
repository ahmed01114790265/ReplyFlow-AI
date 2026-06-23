using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReplyFlow.Features.Leads.Comman.Mapping
{
    public interface IBusinessTypeFactory
    {
        List<SelectListItem> Create();
    }
}
