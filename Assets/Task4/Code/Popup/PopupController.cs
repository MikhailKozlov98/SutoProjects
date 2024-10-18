using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CurrencyTask4
{
    public sealed class PopupController : MonoBehaviour
    {
        [SerializeField] private Button _forMoneyButton;
        [SerializeField] private Button _forRubinButton;
        [SerializeField] private PopupView _popupView;
        private PopupPresenter _presenter;

        private CancellationTokenSource _cancellationTokenSource;
        private ProductStorage _productStorage;
        private ProductBuyer _productBuyer;

        [Inject]
        private void Construct(ProductStorage productStorage, ProductBuyer productBuyer)
        {
            _productStorage = productStorage;
            _productBuyer = productBuyer;
        }

        private void Start()
        {
            _presenter = new PopupPresenter(_popupView);

            _forMoneyButton.onClick.AddListener(OnButtonMoneyClicked);
            _forRubinButton.onClick.AddListener(OnButtonRubinClicked);

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();

            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void OnButtonMoneyClicked()
        {
            ShowPopupForMoneyAsync(_cancellationTokenSource.Token).Forget();
        }

        private void OnButtonRubinClicked()
        {
            ShowPopupForRubinsAsync(_cancellationTokenSource.Token).Forget();
        }

        private async UniTaskVoid ShowPopupForMoneyAsync(CancellationToken cancellationToken)
        {
            ProductPresenter productPresenter = _productStorage.GetRandomProductForMoney();

            bool isPositive = await _presenter.ShowPopupAsync(cancellationToken: cancellationToken, productPresenter,
                _productBuyer.CanBuyForMoney(productPresenter));
            if (isPositive)
            {
                _productBuyer.BuyForMoney(productPresenter);
            }
            else
            {
                print("Отмена покупки");
            }
        }

        private async UniTaskVoid ShowPopupForRubinsAsync(CancellationToken cancellationToken)
        {
            ProductPresenter productPresenter = _productStorage.GetRandomProductForRubins();

            bool isPositive = await _presenter.ShowPopupAsync(cancellationToken: cancellationToken, productPresenter,
                _productBuyer.CanBuyForRubin(productPresenter));
            if (isPositive)
            {
                _productBuyer.BuyForRubin(productPresenter);
            }
            else
            {
                print("Отмена");
            }
        }

        private void OnDestroy()
        {
            _presenter = null;
            _forMoneyButton.onClick.RemoveListener(OnButtonMoneyClicked);
            _forRubinButton.onClick.RemoveListener(OnButtonRubinClicked);
        }
    }
}
