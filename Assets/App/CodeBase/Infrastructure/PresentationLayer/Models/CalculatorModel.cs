using System;

namespace App.CodeBase.Infrastructure.PresentationLayer.Models
{
    public class CalculatorModel : ICalculatorModel
    {
        public event Action OnCalculate;
        private const string ERROR_MESSAGE = "Error";
 
        public string Calculate(string inputString)
        {
            string[] numbers = inputString.Split('+');
        
            if (numbers.Length != 2)
            {
                return $"{inputString}={ERROR_MESSAGE}";
            }
        
            if (int.TryParse(numbers[0], out int num1) && int.TryParse(numbers[1], out int num2))
            {
                int sum = num1 + num2;
                OnCalculate?.Invoke();
                return $"{inputString}={sum}";
            }

            return $"{inputString}={ERROR_MESSAGE}";
        }
    
        public bool IsValidInput(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '+')
                {
                    return false;
                }
            }
            return true;
        } 
    }
}
