using System;
using App.CodeBase.Extension;
using App.CodeBase.Infrastructure.DataLayer.Services;
using UnityEngine;
using VContainer;

namespace App.CodeBase.Infrastructure.DomainLayer.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS_KEY = "Progress-key";
        private readonly IPersistentProgressService _progressService;
        public event Action OnSave;
   
        [Inject]
        public SaveLoadService(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }
    
        public void SaveProgress()
        {
            string json = _progressService.ProgressData.ToJson();
            PlayerPrefs.SetString(PROGRESS_KEY, json);
        
            OnSave?.Invoke();
        }
    
        public Progress LoadProgress()
        {
            return PlayerPrefs.GetString(PROGRESS_KEY)?.ToDeserialized<Progress>();
        }
    }
}
