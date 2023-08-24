namespace App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base
{
    public interface IStateMachine
    {
        void SwitchState<TState>() where TState : IState;
    }
}
