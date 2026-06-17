using Microsoft.EntityFrameworkCore;
using ReplyFlow.Shared.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// MVC
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


app.UseAuthorization();

// MVC Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();