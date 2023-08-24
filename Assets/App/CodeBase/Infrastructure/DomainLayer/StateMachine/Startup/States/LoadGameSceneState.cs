using App.CodeBase.Infrastructure.DomainLayer.Services.StateMachine;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;
using UnityEngine.SceneManagement;
using VContainer;

namespace App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup.States
{
    public class LoadGameSceneState : IState, IEnterableState
    {
        private readonly IStateMachineService _stateMachineService;
        private const string SCENE_NAME = "Main";

        
        [Inject]
        public LoadGameSceneState(IStateMachineService stateMachineService)
        {
            _stateMachineService = stateMachineService;
        }

        public void Enter()
        {
          
            SceneManager.LoadScene(SCENE_NAME);
        }
    }
}
