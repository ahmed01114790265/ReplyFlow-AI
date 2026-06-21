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
    // Clear out or prepend the new vertical slice formats
    // {1} is the Controller/Feature name, {0} is the View name
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/Features/{1}/{0}.cshtml");
    options.ViewLocationFormats.Add("/Features/{1}/{1}.cshtml"); // Match folder name
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