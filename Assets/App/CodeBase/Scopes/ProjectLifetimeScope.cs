using App.CodeBase.Infrastructure.DataLayer.Services;
using App.CodeBase.Infrastructure.DomainLayer.Factories.StateMachineFactory;
using App.CodeBase.Infrastructure.DomainLayer.Services.SaveLoad;
using App.CodeBase.Infrastructure.DomainLayer.Services.StateMachine;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup;
using App.CodeBase.Infrastructure.DomainLayer.StateMachine.Startup.States;
using App.CodeBase.Infrastructure.PresentationLayer.Models;
using VContainer;
using VContainer.Unity;

namespace App.CodeBase.Scopes
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterFactories(builder);
            RegisterModels(builder);
            builder.RegisterBuildCallback(OnRegisterComplete);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<IStateMachineService, StateMachineService>(Lifetime.Singleton);
            builder.Register<IObjectResolver, Container>(Lifetime.Singleton);
            builder.Register<IPersistentProgressService, PersistentProgressService>(Lifetime.Singleton);
            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
        }
        
        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<IStateMachineFactory, StateMachineFactory>(Lifetime.Singleton);
        }
        
        private void RegisterModels(IContainerBuilder builder)
        {
            builder.Register<ICalculatorModel, CalculatorModel>(Lifetime.Singleton);
        }

        private void OnRegisterComplete(IObjectResolver objectResolver)
        {
            IStateMachineFactory stateFactory = objectResolver.Resolve<IStateMachineFactory>();
            IStateMachineService stateMachineService = objectResolver.Resolve<IStateMachineService>();
            
            StartupStateMachine startupStateMachine = stateFactory.CreateStateMachine<StartupStateMachine>();
            startupStateMachine.AddState(stateFactory.CreateState<BootstrapState>());
            startupStateMachine.AddState(stateFactory.CreateState<LoadProgressState>());
            startupStateMachine.AddState(stateFactory.CreateState<LoadGameSceneState>());
            stateMachineService.AddStateMachine(startupStateMachine);
        }
    }
}
