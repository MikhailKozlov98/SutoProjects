using Zenject;

namespace CharacterTask1
{
    internal sealed class CharacterInstaller
    {
        public CharacterInstaller(DiContainer container)
        {
            container.Bind<CharacterSelector>().AsSingle();
            container.Bind<CharacterPresenterFactory>().AsSingle();
        }
    }
}
