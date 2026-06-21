namespace ReplyFlow.Features.Leads.Comman.Enums
{
    public static class BusinessTypeExtensions
    {
        public static string DisplayName(this BusinessType businessType)
        {
            return businessType switch
            {
                BusinessType.Ecommerce => "E-Commerce Store",
                BusinessType.Retail => "Retail Store",
                BusinessType.Restaurant => "Restaurant",
                BusinessType.Hospitality => "Hotel & Hospitality",
                BusinessType.Clinic => "Medical Clinic",
                BusinessType.Healthcare => "Healthcare Provider",
                BusinessType.RealEstate => "Real Estate",
                BusinessType.Education => "Education & Training",
                BusinessType.Agency => "Marketing Agency",
                BusinessType.Consulting => "Consulting Business",
                BusinessType.SaaS => "Software as a Service (SaaS)",
                BusinessType.Fintech => "Financial Technology (FinTech)",
                BusinessType.Logistics => "Logistics & Shipping",
                BusinessType.Manufacturing => "Manufacturing",
                BusinessType.Construction => "Construction",
                BusinessType.Automotive => "Automotive",
                BusinessType.BeautyAndWellness => "Beauty & Wellness",
                BusinessType.Legal => "Legal Services",
                BusinessType.Entertainment => "Entertainment & Media",
                BusinessType.Agriculture => "Agriculture",
                BusinessType.NonProfit => "Non-Profit Organization",
                BusinessType.Government => "Government Entity",
                _ => "Other Business Type"
            };
        }
    }
}
