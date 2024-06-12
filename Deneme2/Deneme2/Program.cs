using Deneme2.Models;
using Deneme2.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DBData>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient(typeof(IRepository<>), typeof(MainRepository<>));
builder.Services.AddSingleton<User>();

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseAuthorization();

app.MapRazorPages();

app.Run();
