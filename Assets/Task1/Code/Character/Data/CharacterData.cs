using UnityEngine;

namespace CharacterTask1
{
    [CreateAssetMenu(fileName = "Character", menuName = "CharacterData/New Character")]
    public sealed class CharacterData : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private int _health;

        public Sprite Icon => _icon;
        public string Name => _name;
        public int Health => _health;
    }
}
