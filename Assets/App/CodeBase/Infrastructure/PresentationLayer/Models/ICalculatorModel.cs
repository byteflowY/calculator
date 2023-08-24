using System;

namespace App.CodeBase.Infrastructure.PresentationLayer.Models
{
    public interface ICalculatorModel
    {
        string Calculate(string inputString);
        bool IsValidInput(string input);
        event Action OnCalculate;
    }
}