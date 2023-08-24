using System;
using System.Reflection;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Base;
using VContainer;

namespace App.CodeBase.Infrastructure.DomainLayer.Factories.StateMachineFactory
{
    public class StateMachineFactory : IStateMachineFactory
    {
        private readonly IObjectResolver _container;

        [Inject]
        public StateMachineFactory(IObjectResolver container)
        {
            _container = container;
        }

        public TState CreateState<TState>() where TState : IState
        {
            Type type = typeof(TState);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);

            if (constructor != null)
            {
                TState instance = (TState)constructor.Invoke(null);
                _container.Inject(instance);
                return instance;
            }
            else
            {
                ConstructorInfo[] constructors = type.GetConstructors();
                ParameterInfo[] parameters = constructors[0].GetParameters();
                object[] args = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    args[i] = _container.Resolve(parameters[i].ParameterType);
                }
                TState instance = (TState)constructors[0].Invoke(args);
                _container.Inject(instance);
                return instance;
            }
        }

        public TStateMachine CreateStateMachine<TStateMachine>() where TStateMachine : IStateMachine
        {
            Type type = typeof(TStateMachine);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);

            if (constructor != null)
            {
                TStateMachine instance = (TStateMachine)constructor.Invoke(null);
                _container.Inject(instance);
                return instance;
            }
            else
            {
                ConstructorInfo[] constructors = type.GetConstructors();
                ParameterInfo[] parameters = constructors[0].GetParameters();
                object[] args = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    args[i] = _container.Resolve(parameters[i].ParameterType);
                }
                TStateMachine instance = (TStateMachine)constructors[0].Invoke(args);
                return instance;
            }
        }
    }
}
