using Zenject;

namespace CharacterTask2
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            new CharacterInstaller(Container);
        }
    }

}
