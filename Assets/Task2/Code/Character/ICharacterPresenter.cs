using UniRx;

namespace CharacterTask2
{
    public interface ICharacterPresenter : IPresenter
    {
        string Name { get; }
        int MaxHealth { get; }
        IReadOnlyReactiveProperty<int> Health { get; }
        IReadOnlyReactiveProperty<float> HealthShare { get; }
    }
}
