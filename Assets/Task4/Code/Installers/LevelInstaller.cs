using Zenject;

namespace CurrencyTask4
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ProductStorage productStorage = FindObjectOfType<ProductStorage>();
            new ProductInstaller(Container, productStorage);

            new CurrencyInstaller(Container);
        }
    }
}
