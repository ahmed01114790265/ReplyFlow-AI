using MediatR;
using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Leads.Comman.Mapping;
using ReplyFlow.Shared.Persistence;

var builder = WebApplication.CreateBuilder(args);
//Register in DI
builder.Services.AddScoped<IBusinessTypeFactory, BusinessTypeFactory>();

// MVC
builder.Services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Clear();

    // 1. Precise Feature Path: /Features/Leads/CreateLead/Create.cshtml
    // Since {1} is "Lead" and {0} is "Create", we combine them to look inside "CreateLead"
    options.ViewLocationFormats.Add("/Features/Leads/{0}{1}/{0}.cshtml"); // Searches: /Features/Leads/CreateLead/Create.cshtml

    // 2. Fallback for features that don't have a prefixing verb (e.g., Index, Details)
    options.ViewLocationFormats.Add("/Features/Leads/{1}/{0}.cshtml");

    // 3. Shared layout fallback (if your _Layout.cshtml or partials live in a shared features folder)
    options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");
});
builder.Services.AddControllersWithViews();

// DB Context
builder.Services.AddDbContext<ReplyFlowDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(ReplyFlowDbContext).Assembly,
        typeof(Program).Assembly
    );
});
// HttpClient (for OpenAI / WhatsApp)
builder.Services.AddHttpClient();

// Auth (later Identity if needed)
builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Lead}/{action=Create}/{id?}");

app.Run();