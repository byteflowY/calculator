namespace App.CodeBase.Infrastructure.PresentationLayer.Presenters
{
    public interface ICalculatorPresenter
    {
        string GetHistoryText();
        string GetInputHistoryText();
        void SaveInput();
        void SaveHistory();
        string GetCalculatedText();
        void OnCalculateClicked();
    }
}