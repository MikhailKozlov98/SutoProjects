using System.Threading;
using Cysharp.Threading.Tasks;

namespace CurrencyTask4
{
    public sealed class PopupViewModel
    {
        // Хранит Task, которую может вернуть
        private readonly UniTaskCompletionSource<bool> _completionSource = new();

        public void PositiveResponse() // Вызывает пользователь во view
        {
            _completionSource.TrySetResult(true); // Завершает Task
        }

        public void NegativeResponse()
        {
            _completionSource.TrySetResult(false);
        }

        internal async UniTask<bool> OnResponceAsync(CancellationToken cancellationToken)
        {
            return await _completionSource.Task;
        }
    }
}
