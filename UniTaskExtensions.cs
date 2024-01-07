using Cysharp.Threading.Tasks;

namespace RBronfenBova.FiniteStateMachine
{
    public static class UniTaskExtensions
    {
        public static UniTask.Awaiter GetAwaiter(this UniTask? uniTask) =>
            uniTask?.GetAwaiter() ?? UniTask.CompletedTask.GetAwaiter();
    }
}