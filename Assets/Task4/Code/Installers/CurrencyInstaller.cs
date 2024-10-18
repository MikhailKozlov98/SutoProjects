using Zenject;

namespace CurrencyTask4
{
    internal sealed class CurrencyInstaller
    {
        public CurrencyInstaller(DiContainer container)
        {
            container.Bind<MoneyStorage>().AsSingle().WithArguments(10000L).NonLazy();
            container.Bind<RubinStorage>().AsSingle().WithArguments(10000L).NonLazy();
        }
    }
}
