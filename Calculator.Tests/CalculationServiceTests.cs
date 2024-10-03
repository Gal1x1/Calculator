// Importuje základní knihovnu pro práci s daty a výjimkami
using System;
// Importuje knihovnu pro práci s testováním v Microsoft Visual Studio
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Importuje službu výpočtů z aplikace Calculator
using Calculator.Services;

namespace Calculator.Tests
{
    // Označuje třídu jako třídu s jednotkovými testy
    [TestClass]
    public class CalculationServiceTests
    {
        // Soukromá proměnná pro referenci na službu výpočtů
        private ICalculationService _service;

        // Metoda Setup bude volána před každým testem, aby inicializovala službu výpočtů
        [TestInitialize]
        public void Setup()
        {
            _service = new CalculationService(); // Vytváří novou instanci služby výpočtů
        }

        // Test pro sčítání
        [TestMethod]
        public void TestAddition()
        {
            // Volá metodu Calculate pro sčítání 2 + 3
            int result = _service.Calculate(2, 3, "+");
            // Kontroluje, zda je výsledek roven 5
            Assert.AreEqual(5, result);
        }

        // Test pro odečítání
        [TestMethod]
        public void TestSubtraction()
        {
            // Volá metodu Calculate pro odečítání 5 - 3
            int result = _service.Calculate(5, 3, "-");
            // Kontroluje, zda je výsledek roven 2
            Assert.AreEqual(2, result);
        }

        // Test pro násobení
        [TestMethod]
        public void TestMultiplication()
        {
            // Volá metodu Calculate pro násobení 4 * 2
            int result = _service.Calculate(4, 2, "*");
            // Kontroluje, zda je výsledek roven 8
            Assert.AreEqual(8, result);
        }

        // Test pro dělení
        [TestMethod]
        public void TestDivision()
        {
            // Volá metodu Calculate pro dělení 6 / 2
            int result = _service.Calculate(6, 2, "/");
            // Kontroluje, zda je výsledek roven 3
            Assert.AreEqual(3, result);
        }

        // Test pro dělení nulou (očekává výjimku DivideByZeroException)
        [TestMethod]
        public void TestDivisionByZero()
        {
            // Kontroluje, zda metoda Calculate vyvolá výjimku při dělení 2 / 0
            Assert.ThrowsException<DivideByZeroException>(() => _service.Calculate(2, 0, "/"));
        }
    }
}
