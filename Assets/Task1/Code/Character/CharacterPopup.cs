using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterTask1
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Image _icon;

        public void Show(IPresenter args)
        {
            if (args is not ICharacterPresenter presenter) return;

            gameObject.SetActive(true);

            _nameText.text = presenter.Name;
            _icon.sprite = presenter.Icon;
        }
    }
}
