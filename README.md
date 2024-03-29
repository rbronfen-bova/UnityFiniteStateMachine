
## Installation
Unity Editor &#8594; Window (top) &#8594; Package Manager &#8594; Press "+" (top-left) &#8594;  
Install package from git URL...
```
https://github.com/rbronfen-bova/UnityFiniteStateMachine.git
```
This package uses **UniTask** and **Zenject**.

## Theory
MVC Model:  
**Views** - Unity components such as Text, Image etc.  
**Controllers** - MonoBehaviours.  
**Models** - Domain Models containing data of the game and corresponding logic.  

**+ State** - a part of the **Model**, an attempt to decouple data from logic. **State** contains logic (functionality) and a reference to the **Model** (data).  
**+ State Machine** - the manager of states, <ins>injected</ins> into the **Model**.

## Usage:
- Create your own model class, create state class for this model by deriving it from `BaseState<>`, for example  
`public class BootstrapState : BaseState<MyApplication> {}`  
`public class BootstrapState : BaseState {}`
- Bind state machine factory:  
`Container.BindStateMachineFactoryForModel<MyApplication>();`  
`Container.BindStateMachineFactory();`
- Bind states: `Container.BindStates();`.  
- Inject StateMachineFactory:  
`public MyApplication(StateMachineFactory<MyApplication> stateMachineFactory)`  
`public MyApplication(StateMachineFactory stateMachineFactory)`  
- Set an initial state for the state machine: `_stateMachine.SetStateAsync<BootstrapState>().Forget();`.
