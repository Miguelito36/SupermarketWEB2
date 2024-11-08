using Microsoft.EntityFrameworkCore;
using SupermarketWEB2.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        //Agregando el contexto SupermarketContext a la aplicacion 
        builder.Services.AddDbContext<SupermarketContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SupermarketDB"))
        );
        builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
        {
            options.Cookie.Name = "MyCookieAuth";
            options.LoginPath = "/Account/Login";
        });

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}
