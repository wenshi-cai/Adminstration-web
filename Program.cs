using SmartParkingAdmin.Services;
using SmartParkingAdmin.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 注册 HttpClient 工厂
builder.Services.AddHttpClient();

// 注册管理端 API 服务
builder.Services.AddScoped<IAdminApi, AdminApi>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();