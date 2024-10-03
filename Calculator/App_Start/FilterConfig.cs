// Importuje knihovnu System.Web pro práci s webovými aplikacemi
using System.Web;
// Importuje knihovnu MVC pro práci s filtry a řízením výjimek
using System.Web.Mvc;

namespace Calculator
{
    // Třída pro konfiguraci globálních filtrů aplikace
    public class FilterConfig
    {
        // Metoda pro registraci globálních filtrů
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Přidání filtru pro zpracování chyb (HandleErrorAttribute)
            filters.Add(new HandleErrorAttribute());
        }
    }
}
