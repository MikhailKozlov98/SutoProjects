using System.Threading;
using Cysharp.Threading.Tasks;

namespace CurrencyTask4
{
    public class PopupPresenter
    {
        private readonly PopupView _popupView;

        public PopupPresenter(PopupView popupView)
        {
            _popupView = popupView;
        }

        internal async UniTask<bool> ShowPopupAsync(CancellationToken cancellationToken, ProductPresenter presenter,
            bool enoughCurrency)
        {
            PopupViewModel viewModel = new();
            _popupView.Initialize(viewModel, presenter, enoughCurrency);
            _popupView.Show();
            return await viewModel.OnResponceAsync(cancellationToken: cancellationToken);
        }
    }
}
