using UnityEngine;

namespace CurrencyTask4
{
    public sealed class ProductBuyer
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly RubinStorage _rubinStorage;

        public ProductBuyer(MoneyStorage moneyStorage, RubinStorage rubinStorage)
        {
            _moneyStorage = moneyStorage;
            _rubinStorage = rubinStorage;
        }

        public void BuyForMoney(ProductPresenter presenter)
        {
            if (CanBuyForMoney(presenter))
            {
                _moneyStorage.SpendMoney(presenter.Price);
                Debug.Log($"<color=green>Product {presenter.ProductName} was bought for money</color>.");
            }
            else
            {
                Debug.Log($"<color=red>Mot enough money for product {presenter.ProductName}.</color>");
            }
        }

        public bool CanBuyForMoney(ProductPresenter presenter)
        {
            return _moneyStorage.Money.Value >= presenter.Price;
        }

        public void BuyForRubin(ProductPresenter presenter)
        {
            if (CanBuyForRubin(presenter))
            {
                _rubinStorage.SpendRubin(presenter.Price);
                Debug.Log($"<color=yellow>Product {presenter.ProductName} was bought for rubins</color>.");
            }
            else
            {
                Debug.Log($"<color=red>Mot enough rubins for product {presenter.ProductName}.</color>");
            }
        }

        public bool CanBuyForRubin(ProductPresenter presenter)
        {
            return _rubinStorage.Rubin.Value >= presenter.Price;
        }
    }
}
