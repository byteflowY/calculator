namespace App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base
{
    public interface IEnterableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }
    
    public interface IState
    {
        
    }
}