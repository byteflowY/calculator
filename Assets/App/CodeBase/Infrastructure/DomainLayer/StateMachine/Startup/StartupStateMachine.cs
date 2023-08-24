using System;
using System.Collections.Generic;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;

namespace App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup
{
    public class StartupStateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states = new();
        private IState _currentState;


        public void AddState(IState state)
        {
            _states.Add(state.GetType(), state);
        }
        
        public void SwitchState<TState>() where TState : IState
        {
            ExitPreviousState();
            SetNewState<TState>();
            EnterNewState();
        }
        
        private void EnterNewState()
        {
            if (_currentState is IEnterableState enterable)
            {
                enterable.Enter();
            }
        }
        
        private void ExitPreviousState()
        {
            if (_currentState is IExitableState exitable)
            {
                exitable.Exit();
            }
        }

        private void SetNewState<TState>() where TState : IState
        {
            _currentState = GetState<TState>();
        }
        
        private TState GetState<TState>() where TState : IState
        {
            return (TState)_states[typeof(TState)];
        }
    }
}
