using App.CodeBase.Infrastructure.DataLayer.Services;
using App.CodeBase.Infrastructure.DomainLayer.Services.SaveLoad;
using App.CodeBase.Infrastructure.PresentationLayer.Models;
using App.CodeBase.Infrastructure.PresentationLayer.UI;
using UnityEngine;
using VContainer;

namespace App.CodeBase.Infrastructure.PresentationLayer.Presenters
{
    public class CalculatorPresenter : MonoBehaviour
    {
        [SerializeField] private CalculatorView _calculatorView;
        private ICalculatorModel _calculatorModel;
        private IPersistentProgressService _persistentProgressService;
        private ISaveLoadService _saveLoadService;
        private string _calculatedText;

        [Inject]
        public void Construct(ICalculatorModel calculatorModel, IPersistentProgressService persistentProgressService,
            ISaveLoadService saveLoadService)
        {
            _calculatorModel = calculatorModel;
            _persistentProgressService = persistentProgressService;
            _saveLoadService = saveLoadService;
        }

        public string GetCalculatedText()
        {
            return _calculatedText;
        }

        public string GetHistoryText()
        {
            return _persistentProgressService.ProgressData.HistoryTextJson;
        }

        public string GetInputHistoryText()
        {
            return _persistentProgressService.ProgressData.HistoryInputFieldJson;
        }

        public void OnCalculateClicked()
        {
            string inputString = _calculatorView.GetInputFieldText();
            _calculatedText = _calculatorModel.Calculate(inputString);
            _calculatorView.UpdateHistoryText();
            _calculatorView.CleanUpInput();
            SaveHistory();
        }

        public void SaveInput()
        {
            _persistentProgressService.ProgressData.HistoryInputFieldJson = _calculatorView.GetInputFieldText();
            _saveLoadService.SaveProgress();
        }

        private void SaveHistory()
        {
            _persistentProgressService.ProgressData.HistoryTextJson = _calculatorView.GetHistoryText();
            _saveLoadService.SaveProgress();
        }
    }
}