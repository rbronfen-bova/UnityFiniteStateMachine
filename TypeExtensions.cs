using System;

namespace RBronfenBova.FiniteStateMachine
{
    public static class TypeExtensions
    {
        public static bool IsSubclassOfOpenGeneric(this Type type, Type openGenericType)
        {
            if (type == null)
                throw new ArgumentNullException(nameof (type));
            for (var baseType = type.BaseType; baseType != null; baseType = baseType.BaseType)
            {
                if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == openGenericType)
                    return true;
            }
            return false;
        }
    }
}