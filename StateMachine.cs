using Cysharp.Threading.Tasks;
using Zenject;

namespace RBronfenBova.FiniteStateMachine
{
    public class StateMachine
    {
        private readonly DiContainer _container;
        private BaseState _currentState;
        
        internal StateMachine(DiContainer container)
        {
            _container = container;
        }

        public async UniTask SetStateAsync<TState>() where TState: BaseState
        {
            await _currentState?.OnExitAsync();
            _currentState = CreateState<TState>();
            await _currentState.OnEnterAsync();
        }

        private TState CreateState<TState>() where TState: BaseState
        {
            var state = _container.Resolve<TState>();
            state.StateMachine = this;
            return state;
        }
    }
    
    public class StateMachine<TModel>
    {
        private readonly TModel _model;
        private readonly DiContainer _container;
        private BaseState<TModel> _currentState;

        internal StateMachine(TModel model, DiContainer container)
        {
            _model = model;
            _container = container;
        }

        public async UniTask SetStateAsync<TState>() where TState: BaseState<TModel>
        {
            await _currentState?.OnExitAsync();
            _currentState = CreateState<TState>();
            await _currentState.OnEnterAsync();
        }

        private TState CreateState<TState>() where TState: BaseState<TModel>
        {
            var state = _container.Resolve<TState>();
            state.Model = _model;
            state.StateMachine = this;
            return state;
        }
    }
}
