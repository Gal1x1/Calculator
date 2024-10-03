// Importuje knihovnu MVC pro práci s routováním a požadavky HTTP
using System.Web.Mvc;
// Importuje knihovnu pro práci s routováním v ASP.NET
using System.Web.Routing;

public class RouteConfig
{
    // Metoda pro registraci směrování (routování) v aplikaci
    public static void RegisterRoutes(RouteCollection routes)
    {
        // Ignoruje určité typy požadavků, které mají koncovku .axd (např. soubory trace.axd)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        // Definuje výchozí pravidlo směrování
        routes.MapRoute(
            name: "Default",  // Název směrování
            url: "{controller}/{action}/{id}",  // Struktura URL: kontroler, akce a volitelný identifikátor
            defaults: new { controller = "Calculator", action = "Index", id = UrlParameter.Optional }  // Výchozí hodnoty
        );
    }
}
