using Zenject;

namespace CharacterTask2
{
    internal sealed class CharacterInstaller
    {
        public CharacterInstaller(DiContainer container)
        {
            container.Bind<CharacterPresenterFactory>().AsSingle();
        }
    }

}
