using TestUkrposhta.Extentions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Injecting
builder.Services.InjectRepositories(configuration);
builder.Services.InjectBusinessServices();
builder.Services.InjectAutoMapper();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Company}/{action=Index}/{id?}");

app.Run();
