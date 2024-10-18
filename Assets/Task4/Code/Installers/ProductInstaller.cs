using Zenject;

namespace CurrencyTask4
{
    internal sealed class ProductInstaller
    {
        public ProductInstaller(DiContainer container, ProductStorage productStorage)
        {
            container.Bind<ProductStorage>().FromInstance(productStorage).AsSingle();
            container.Bind<ProductBuyer>().AsSingle().NonLazy();
        }
    }
}
