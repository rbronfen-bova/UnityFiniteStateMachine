using Zenject;

namespace RBronfenBova.FiniteStateMachine
{
    public class StateMachineFactory : PlaceholderFactory<StateMachine> {}

    public class StateMachineFactory<TModel> : PlaceholderFactory<TModel, StateMachine<TModel>> {}
}