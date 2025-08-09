var builder = WebApplication.CreateBuilder(args);

// MVC + API controllers
builder.Services.AddControllersWithViews();

// CORS: cho phép client gọi API trong môi trường dev
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Swagger (tuỳ chọn, nhưng tiện để test)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAll"); // <- bật CORS trước Authorization

app.UseAuthorization();

// Map cho API dùng attribute routing: [Route("api/[controller]")]
app.MapControllers();

// Route MVC cho View (Home/Index mặc định)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
