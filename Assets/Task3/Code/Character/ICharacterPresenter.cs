using UniRx;
using UnityEngine;

namespace CharacterTask3
{
    public interface ICharacterPresenter : IPresenter
    {
        string Name { get; }
        Sprite Icon { get; }
        ReactiveCommand SelectCommand { get; }
    }
}
