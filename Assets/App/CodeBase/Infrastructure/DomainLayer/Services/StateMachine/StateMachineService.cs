using System;
using System.Collections.Generic;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;
using UnityEngine;

namespace App.CodeBase.Infrastructure.DomainLayer.Services.StateMachine
{
    public class StateMachineService : IStateMachineService
    {
        private Dictionary<Type, IStateMachine> _stateMachines = new();

        
        public void AddStateMachine(IStateMachine stateMachine)
        {
            _stateMachines.Add(stateMachine.GetType(), stateMachine);
        }

        public void ChangeState<TState, TStateMachine>() where TState : IState 
                                                         where TStateMachine : IStateMachine
        {
            if (_stateMachines.TryGetValue(typeof(TStateMachine), out IStateMachine stateMachine))
            {
                stateMachine.SwitchState<TState>();
            }
            else
            {
                Debug.LogError("State machine not found");
            }
        }
    }
}
