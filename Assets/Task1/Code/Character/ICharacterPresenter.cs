using UnityEngine;

namespace CharacterTask1
{
    public interface ICharacterPresenter : IPresenter
    {
        string Name { get; }
        Sprite Icon { get; }
    }
}
