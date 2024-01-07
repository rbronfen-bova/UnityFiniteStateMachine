using Cysharp.Threading.Tasks;

namespace RBronfenBova.FiniteStateMachine
{
    internal interface IState
    {
        UniTask OnEnterAsync();

        UniTask OnExitAsync();
    }
    
    public abstract class BaseState : IState
    {
        public StateMachine StateMachine { get; set; }
        
        public virtual UniTask OnEnterAsync() =>
            UniTask.CompletedTask;

        public virtual UniTask OnExitAsync() =>
            UniTask.CompletedTask;
        
        protected UniTask SetStateAsync<TState>() where TState: BaseState, new() =>
            StateMachine.SetStateAsync<TState>();
    }
    
    public abstract class BaseState<TModel> : IState
    {
        public StateMachine<TModel> StateMachine { get; set; }

        public TModel Model { get; set; }

        public virtual UniTask OnEnterAsync() =>
            UniTask.CompletedTask;

        public virtual UniTask OnExitAsync() =>
            UniTask.CompletedTask;
        
        protected UniTask SetStateAsync<TState>() where TState: BaseState<TModel>, new() =>
            StateMachine.SetStateAsync<TState>();
    }
}