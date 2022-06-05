using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RDKSDatabase.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RDKSDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RDKSDatabaseContext") ?? throw new InvalidOperationException("Connection string 'RDKSDatabaseContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<RDKSDatabaseContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
