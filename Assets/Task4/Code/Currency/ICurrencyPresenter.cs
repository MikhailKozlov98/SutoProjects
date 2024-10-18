using UniRx;

namespace CurrencyTask4
{
    public interface ICurrencyPresenter
    {
        LongReactiveProperty Currency { get; }
    }
}
