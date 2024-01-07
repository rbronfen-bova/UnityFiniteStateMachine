using System.Linq;
using System.Reflection;
using Zenject;

namespace RBronfenBova.FiniteStateMachine
{
    public static class DiContainerExtensions
    {
        public static void BindStateMachineFactory(this DiContainer container) =>
            container.BindFactory<StateMachine, StateMachineFactory>();
        
        public static void BindStateMachineFactoryForModel<TModel>(this DiContainer container) =>
            container.BindFactory<TModel, StateMachine<TModel>, StateMachineFactory<TModel>>();
        
        public static void BindStates(this DiContainer container)
        {
            var assembly = Assembly.GetCallingAssembly();
            var types = assembly.GetTypes().Where(_ => _.IsClass && !_.IsAbstract && typeof(IState).IsAssignableFrom(_));
            foreach (var type in types)
            {
                container.Bind(type).AsTransient();
            }
        }
    }
}