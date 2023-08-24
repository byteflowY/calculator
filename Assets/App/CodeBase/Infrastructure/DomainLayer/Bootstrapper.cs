using App.CodeBase.Infrastructure.DomainLayer.Services.StateMachine;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup.States;
using UnityEngine;
using VContainer;

namespace App.CodeBase.Infrastructure.DomainLayer
{
    public class Bootstrapper : MonoBehaviour
    {
        private IStateMachineService _stateMachineService;
        private IObjectResolver _objectResolver;

        
        [Inject]
        private void Construct(IStateMachineService stateMachineService)
        {
            _stateMachineService = stateMachineService;
        }

         private void Start()
         {
             SwitchState();
         }

         private void SwitchState()
         {
             _stateMachineService.ChangeState<BootstrapState, StartupStateMachine>();
         }
    }
}
