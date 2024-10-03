// Importuje hlavní prostor jmen aplikace Calculator
using Calculator;
// Importuje controller HomeController pro testování
using Calculator.Controllers;
// Importuje knihovnu pro testování v prostředí Visual Studio
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Importuje MVC třídy pro práci s ViewResult a ostatními objekty MVC
using System.Web.Mvc;

namespace Calculator.Tests.Controllers
{
    // Označuje třídu jako třídu pro testování
    [TestClass]
    public class HomeControllerTest
    {
        // Testuje metodu Index kontroleru HomeController
        [TestMethod]
        public void Index()
        {
            // Arrange - Příprava: Vytvoří instanci HomeControlleru
            HomeController controller = new HomeController();

            // Act - Akce: Zavolá metodu Index kontroleru
            ViewResult result = controller.Index() as ViewResult;

            // Assert - Ověření: Kontroluje, zda výsledek není null (že metoda vrací nějaký ViewResult)
            Assert.IsNotNull(result);
        }

        // Testuje metodu About kontroleru HomeController
        [TestMethod]
        public void About()
        {
            // Arrange - Příprava: Vytvoří instanci HomeControlleru
            HomeController controller = new HomeController();

            // Act - Akce: Zavolá metodu About kontroleru
            ViewResult result = controller.About() as ViewResult;

            // Assert - Ověření: Kontroluje, zda zpráva v ViewBag odpovídá očekávanému textu
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        // Testuje metodu Contact kontroleru HomeController
        [TestMethod]
        public void Contact()
        {
            // Arrange - Příprava: Vytvoří instanci HomeControlleru
            HomeController controller = new HomeController();

            // Act - Akce: Zavolá metodu Contact kontroleru
            ViewResult result = controller.Contact() as ViewResult;

            // Assert - Ověření: Kontroluje, zda výsledek není null (že metoda vrací nějaký ViewResult)
            Assert.IsNotNull(result);
        }
    }
}
