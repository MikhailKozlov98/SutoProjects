using System;
using UniRx;

namespace CurrencyTask4
{
    public sealed class RubinPresenter : ICurrencyPresenter
    {
        public LongReactiveProperty Currency => _currency;
        private readonly LongReactiveProperty _currency = new LongReactiveProperty();

        private readonly IDisposable _disposable;

        public RubinPresenter(RubinStorage rubinStorage)
        {
            _disposable = rubinStorage.Rubin.Subscribe(OnMoneyChanged);
        }

        private void OnMoneyChanged(long rubin)
        {
            _currency.Value = rubin;
        }

        ~RubinPresenter()
        {
            _disposable.Dispose();
        }
    }
}
