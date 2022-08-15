using Microsoft.EntityFrameworkCore;
using IssueTracker.Data;
using IssueTracker.Pages.Account;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(LoginModel.AuthCookie).AddCookie(LoginModel.AuthCookie, options =>
{
    options.Cookie.Name = LoginModel.AuthCookie;
});

builder.Services.AddDbContext<IssueTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IssueTrackerContext") ?? throw new InvalidOperationException("Connection string 'IssueTrackerContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
