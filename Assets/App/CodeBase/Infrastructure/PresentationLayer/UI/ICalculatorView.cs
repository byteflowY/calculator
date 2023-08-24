namespace App.CodeBase.Infrastructure.PresentationLayer.UI
{
    public interface ICalculatorView
    {
        string GetInputFieldText();
        string GetHistoryText();
        void UpdateHistoryText();
    }
}