using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;

namespace App.CodeBase.Infrastructure.DomainLayer.Factories.StateMachineFactory
{
    public interface IStateMachineFactory
    {
        TState CreateState<TState>() where TState : IState;
        TStateMachine CreateStateMachine<TStateMachine>() where TStateMachine : IStateMachine;
    }
}