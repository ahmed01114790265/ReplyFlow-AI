using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Leads.Handlers;
using ReplyFlow.Features.Leads.Validations;
using ReplyFlow.Shared.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ReplyFlowDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(CreateLeadHandler).Assembly);
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateLeadValidator>();

builder.Services.AddHttpClient();

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
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Leads}/{action=Create}");

app.Run();