using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zenject;

namespace RBronfenBova.FiniteStateMachine
{
    public static class DiContainerExtensions 
    {
        public static void BindStates(this DiContainer container)
        {
            var assembly = Assembly.GetCallingAssembly();
            var stateTypes = FindDerivedTypes(assembly, typeof(ModelState<>));
            foreach (var type in stateTypes)
            {
                container.Bind(type).AsTransient();
            }
        }

        private static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType) =>
            assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOfOpenGeneric(baseType));
    }
}