using UnityEngine;

namespace CharacterTask1
{
    [CreateAssetMenu(fileName = "CharacterCatalog", menuName = "CharacterData/New CharacterCatalog")]
    public sealed class CharacterCatalog : ScriptableObject
    {
        public CharacterData[] Characters;
    }
}
