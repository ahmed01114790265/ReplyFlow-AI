using Microsoft.AspNetCore.Mvc.Rendering;
using ReplyFlow.Features.Leads.Comman.Enums;

namespace ReplyFlow.Features.Leads.Comman.Mapping
{
    public class BusinessTypeFactory : IBusinessTypeFactory
    {
        private static readonly Dictionary<BusinessType, string> _displayNames = new()
    {
        { BusinessType.Ecommerce, "E-commerce" },
        { BusinessType.Retail, "Retail" },
        { BusinessType.Restaurant, "Restaurant" },
        { BusinessType.Hospitality, "Hospitality" },
        { BusinessType.Clinic, "Medical Clinic" },
        { BusinessType.Healthcare, "Healthcare" },
        { BusinessType.RealEstate, "Real Estate" },
        { BusinessType.Education, "Education" },
        { BusinessType.Agency, "Agency" },
        { BusinessType.Consulting, "Consulting" },
        { BusinessType.SaaS, "SaaS" },
        { BusinessType.Fintech, "Fintech" },
        { BusinessType.Logistics, "Logistics" },
        { BusinessType.Manufacturing, "Manufacturing" },
        { BusinessType.Construction, "Construction" },
        { BusinessType.Automotive, "Automotive" },
        { BusinessType.BeautyAndWellness, "Beauty & Wellness" },
        { BusinessType.Legal, "Legal" },
        { BusinessType.Entertainment, "Entertainment" },
        { BusinessType.Agriculture, "Agriculture" },
        { BusinessType.NonProfit, "Non-Profit" },
        { BusinessType.Government, "Government" },
        { BusinessType.Other, "Other" }
    };

        public List<SelectListItem> Create()
        {
            return Enum.GetValues<BusinessType>()
                .Select(type => new SelectListItem
                {
                    Value = ((int)type).ToString(),
                    Text = GetDisplayName(type)
                })
                .ToList();
        }

        private static string GetDisplayName(BusinessType type)
        {
            return _displayNames.TryGetValue(type, out var name)
                ? name
                : type.ToString();
        }
    }
}
