using System;

namespace Calculator.Services
{
    // Интерфейс для службы вычислений
    public interface ICalculationService
    {
        // Метод для выполнения вычислений
        int Calculate(decimal operand1, decimal operand2, string operation);

        // Метод для отправки ошибок
        void SendError(Exception ex);
    }
}
