using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Data.Repositories
{
    public interface ICalculationLogRepository
    {
        void LogCalculation(decimal operand1, decimal operand2, string operation, int result);
    }

}