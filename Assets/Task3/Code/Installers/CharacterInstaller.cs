using Zenject;

namespace CharacterTask3
{
    internal sealed class CharacterInstaller
    {
        public CharacterInstaller(DiContainer container)
        {
            container.Bind<CharacterPresenterFactory>().AsSingle();
        }
    }
}