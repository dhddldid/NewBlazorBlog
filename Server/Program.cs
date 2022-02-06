using Microsoft.EntityFrameworkCore;
using NewBlazorBlog.Server.Data;
using NewBlazorBlog.Server.Pratice.BlazorBlogPost.Services;
using NewBlazorBlog.Server.Services.Foundation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Cosmos
builder.Services.Configure<CosmosDbServiceOptions>(builder.Configuration.GetSection("CosmosDb"));
builder.Services.AddSingleton<CosmosDbService>();

// Pratice
builder.Services.AddTransient<BlogPostService>();

//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>
    (x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
