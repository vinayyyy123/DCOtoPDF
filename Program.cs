using DCOtoPDF.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Services
builder.Services.AddSingleton<WordToPdfService>();
builder.Services.AddSingleton<TemplatePreviewService>();

var app = builder.Build();

// Generate template previews at startup
using (var scope = app.Services.CreateScope())
{
    var previewService = scope.ServiceProvider
        .GetRequiredService<TemplatePreviewService>();

    previewService.GenerateTemplatePreviews();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Resume}/{action=Index}/{id?}");

app.Run();
