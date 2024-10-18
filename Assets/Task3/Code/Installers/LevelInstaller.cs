using Zenject;

namespace CharacterTask3
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            new CharacterInstaller(Container);
        }
    }
}