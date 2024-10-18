using UniRx;

namespace CurrencyTask4
{
    public sealed class RubinStorage
    {
        public IReadOnlyReactiveProperty<long> Rubin => _rubin;
        private readonly ReactiveProperty<long> _rubin;

        public RubinStorage(long rubin)
        {
            _rubin = new LongReactiveProperty(rubin);
        }

        public void SpendRubin(long rubin)
        {
            _rubin.SetValueAndForceNotify(_rubin.Value - rubin);
        }
    }
}
