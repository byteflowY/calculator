using App.CodeBase.Infrastructure.PresentationLayer.Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.CodeBase.Infrastructure.PresentationLayer.UI
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _calculatorInputField;
        [SerializeField] private TMP_Text _historyText;
        [SerializeField] private Button _calculateButton;
        [SerializeField] private CalculatorPresenter _calculatorPresenter;

        private void OnEnable()
        {
            Show();
        }

        private void OnDisable()
        {
            Hide();
        }

        private void SaveInput(string input)
        {
            _calculatorPresenter.SaveInput();
        }

        public string GetInputFieldText()
        {
            return _calculatorInputField.text;
        }
        
        public string GetHistoryText()
        {
            return _historyText.text;
        }

        public void UpdateHistoryText()
        {
            string currentText = _historyText.text;
            string updatedText = $"{_calculatorPresenter.GetCalculatedText()}<br>{currentText}";
            _historyText.text = updatedText;
        }

        private void Show()
        {
            SetHistoryText();
            SetInputFieldHistoryText();
            _calculateButton.onClick.AddListener(_calculatorPresenter.OnCalculateClicked);
            _calculatorInputField.onValueChanged.AddListener(SaveInput);
        }

        private void Hide()
        {
            _calculateButton.onClick.RemoveListener(_calculatorPresenter.OnCalculateClicked);
            _calculatorInputField.onValueChanged.RemoveListener(SaveInput);
        }
        
        private void SetHistoryText()
        {
            string currentText = _historyText.text;
            string updatedText = $"{_calculatorPresenter.GetHistoryText()}<br>{currentText}";
            _historyText.text = updatedText;
        }

        private void SetInputFieldHistoryText()
        {
            _calculatorInputField.text = _calculatorPresenter.GetInputHistoryText();
        }

        public void CleanUpInput()
        {
            _calculatorInputField.text = string.Empty;
        }
    }
}
