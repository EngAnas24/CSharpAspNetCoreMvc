using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core;
using RealEstate.Data;
using RealEstate.Data.Contacts;
using RealEstateData;
using Test_T.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<IDataHelper<RealEstateProperty>, PropertyEntity>();
builder.Services.AddSingleton<IDataHelper<offertype>, OfferTypeEntity>();
builder.Services.AddSingleton<IDataHelper<propertytype>, PropertytypEntitye>();
builder.Services.AddSingleton<IDataHelper<propertystatus>, PropertystatusEntity>();
builder.Services.AddSingleton<IDataHelper<furnishedstatus>, FurnishedstatusEntity>();
builder.Services.AddSingleton<IDataHelper<Bedrooms>, BedroomsEntiity>();
builder.Services.AddSingleton<IDataHelper<Bathrooms>, BathroomsEntity>();
builder.Services.AddSingleton<IDataHelper<Balconys>, BalconysEntity>();
builder.Services.AddSingleton<IDataHelper<Contact>, ContactEntity>();
builder.Services.AddSingleton<IDataHelper<SavedProp>, SavedPropEntity>();
builder.Services.AddSingleton<SavedProp>();
builder.Services.AddSingleton<RealEstateProperty>();
builder.Services.AddSingleton<SavedPropEntity>();





builder.Services.AddSingleton<DBData>();
// Retrieve and populate List<RealEstateProperty> from the database
builder.Services.AddSingleton<List<RealEstateProperty>>(provider =>
{
    using (var scope = provider.CreateScope())
    {
        var dbData = scope.ServiceProvider.GetRequiredService<DBData>();
        return dbData.RealEstateProperty.ToList();
    }
});


// Add logging
builder.Services.AddLogging();


builder.Services.AddRazorPages();

builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("User", p => p.RequireClaim("User", "User"));
    op.AddPolicy("Admin", p => p.RequireClaim("Admin", "Admin"));
}
          );





builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
