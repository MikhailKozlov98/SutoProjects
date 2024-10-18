using System;
using UniRx;

namespace CurrencyTask4
{
    public sealed class MoneyPresenter : ICurrencyPresenter
    {
        public LongReactiveProperty Currency => _currency;
        private readonly LongReactiveProperty _currency = new LongReactiveProperty();

        private readonly IDisposable _disposable;

        public MoneyPresenter(MoneyStorage moneyStorage)
        {
            _disposable = moneyStorage.Money.Subscribe(OnMoneyChanged);
        }

        private void OnMoneyChanged(long money)
        {
            _currency.Value = money;
        }

        ~MoneyPresenter()
        {
            _disposable.Dispose();
        }
    }
}
