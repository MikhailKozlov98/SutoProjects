using UnityEngine;

namespace CharacterTask1
{
    public sealed class CharacterSelector
    {
        internal void Select(CharacterPresenter characterData)
        {
            Debug.Log(characterData.Name);
        }
    }
}
