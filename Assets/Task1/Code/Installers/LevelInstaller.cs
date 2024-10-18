using Zenject;

namespace CharacterTask1
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            new CharacterInstaller(Container);
        }
    }
}
