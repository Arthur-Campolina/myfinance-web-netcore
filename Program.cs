using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Mappers;
using myfinance_web_netcore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.AddNpgsqlDbContext<MyFinanceDbContext>(
    "db",
    static settings => settings.ConnectionString = "Server=localhost;Port=5432;Database=myfinance;User Id=postgres;Password=123456;");
builder.Services.AddAutoMapper(typeof(PlanoContaMap));
builder.Services.AddAutoMapper(typeof(TransacaoMap));
builder.Services.AddTransient<IPlanoContaService, PlanoContaService>();
builder.Services.AddTransient<ITransacaoService, TransacaoService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
