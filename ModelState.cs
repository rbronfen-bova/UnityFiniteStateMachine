using Cysharp.Threading.Tasks;

namespace RBronfenBova.FiniteStateMachine
{
    public abstract class ModelState<TModel>
    {
        public StateMachine<TModel> StateMachine { get; set; }

        public TModel Model { get; set; }

        public virtual UniTask OnEnterAsync() =>
            UniTask.CompletedTask;

        public virtual UniTask OnExitAsync() =>
            UniTask.CompletedTask;
        
        protected UniTask SetStateAsync<TState>() where TState: ModelState<TModel>, new() =>
            StateMachine.SetStateAsync<TState>();
    }
}