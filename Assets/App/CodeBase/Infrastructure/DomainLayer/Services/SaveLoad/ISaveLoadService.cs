using System;
using App.CodeBase.Infrastructure.DataLayer.Services;

namespace App.CodeBase.Infrastructure.DomainLayer.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        event Action OnSave;
        void SaveProgress();
        Progress LoadProgress();
    }
}