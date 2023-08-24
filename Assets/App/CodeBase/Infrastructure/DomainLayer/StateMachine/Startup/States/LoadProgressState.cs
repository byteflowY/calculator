using App.CodeBase.Infrastructure.DataLayer.Services;
using App.CodeBase.Infrastructure.DomainLayer.Services.SaveLoad;
using App.CodeBase.Infrastructure.DomainLayer.Services.StateMachine;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;
using VContainer;

namespace App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup.States
{
    public class LoadProgressState : IState, IEnterableState
    {
        private readonly IStateMachineService _stateMachineService;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        [Inject]
        public LoadProgressState(IStateMachineService stateMachineService, IPersistentProgressService progressService, 
            ISaveLoadService saveLoadService)
        {
            _stateMachineService = stateMachineService;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            SwitchToLoadLevelState();
        }
        
        private void LoadProgressOrInitNew()
        {
            _progressService.ProgressData = _saveLoadService.LoadProgress() ?? NewProgress();
        }
        
        private Progress NewProgress()
        {
            return new Progress();
        }

        private void SwitchToLoadLevelState()
        {
            _stateMachineService.ChangeState<LoadGameSceneState, StartupStateMachine>();
        }
    }
}
