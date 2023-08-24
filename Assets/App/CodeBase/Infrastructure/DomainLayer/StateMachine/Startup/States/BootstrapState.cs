using App.CodeBase.Infrastructure.DomainLayer.Services.StateMachine;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;
using VContainer;

namespace App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup.States
{
    public class BootstrapState : IState, IEnterableState
    {
        private readonly IStateMachineService _stateMachineService;

        [Inject]
        public BootstrapState(IStateMachineService stateMachineService)
        {
            _stateMachineService = stateMachineService;
        }

        public void Enter()
        {
            ChangeState();
        }

        private void ChangeState()
        {
            _stateMachineService.ChangeState<LoadProgressState, StartupStateMachine>();
        }
    }
}
