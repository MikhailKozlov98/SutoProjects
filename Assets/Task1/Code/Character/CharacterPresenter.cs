using UnityEngine;

namespace CharacterTask1
{
    public sealed class CharacterPresenter : ICharacterPresenter
    {
        public string Name { get; }
        public Sprite Icon { get; }

        public CharacterPresenter(CharacterData characterData)
        {
            Name = characterData.Name;
            Icon = characterData.Icon;
        }
    }
}
