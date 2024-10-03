// Importuje základní knihovnu pro MVC framework
using System.Web.Mvc;

namespace Calculator.Controllers
{
    // Třída HomeController je zodpovědná za zpracování požadavků a vrácení odpovědí
    public class HomeController : Controller
    {
        // Akce Index je volána, když uživatel navštíví základní stránku ("/Home/Index")
        public ActionResult Index()
        {
            // Vrací pohled (View), který odpovídá této akci (Index.cshtml ve složce Views/Home)
            return View();
        }

        // Akce About je volána, když uživatel navštíví stránku "/Home/About"
        public ActionResult About()
        {
            // Ukládá zprávu do ViewBag, což umožňuje přístup k této zprávě v pohledu (View)
            ViewBag.Message = "This is Calculator";  // Zpráva pro uživatele

            // Vrací pohled (View), který odpovídá této akci (About.cshtml ve složce Views/Home)
            return View();
        }

        // Akce Contact je volána, když uživatel navštíví stránku "/Home/Contact"
        public ActionResult Contact()
        {
            // Ukládá e-mailovou adresu do ViewBag pro zobrazení v pohledu (View)
            ViewBag.Message = "galicudi@outlook.com";  // Zpráva s e-mailovou adresou

            // Vrací pohled (View), který odpovídá této akci (Contact.cshtml ve složce Views/Home)
            return View();
        }
    }
}
