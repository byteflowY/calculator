using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;

namespace App.CodeBase.Infrastructure.DomainLayer.Services.StateMachine
{
    public interface IStateMachineService
    {
        void AddStateMachine(IStateMachine stateMachine);

        void ChangeState<TState, TStateMachine>() where TState : IState 
                                                  where TStateMachine : IStateMachine;
    }
}