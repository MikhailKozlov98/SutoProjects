using UnityEngine;
using UnityEngine.UI;

namespace CharacterTask3
{
    public sealed class CharacterSelectedPopup : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        public void Show(Sprite newSprite)
        {
            gameObject.SetActive(true);

            UpdateSelectedCharacterIcon(newSprite);
        }

        public void UpdateSelectedCharacterIcon(Sprite newSprite)
        {
            _icon.sprite = newSprite;
        }
    }
}
