using Cysharp.Threading.Tasks;
using Zenject;

namespace RBronfenBova.FiniteStateMachine
{
    public class StateMachine<TModel>
    {
        public TModel Model { get; set; }
        private ModelState<TModel> _currentState;
        private readonly DiContainer _container;

        public StateMachine(DiContainer container)
        {
            _container = container;
        }

        public async UniTask SetStateAsync<TState>() where TState: ModelState<TModel>
        {
            await _currentState?.OnExitAsync();
            _currentState = CreateState<TState>();
            await _currentState.OnEnterAsync();
        }

        private TState CreateState<TState>() where TState: ModelState<TModel>
        {
            var state = _container.Resolve<TState>();
            state.Model = Model;
            state.StateMachine = this;
            return state;
        }
    }
}
