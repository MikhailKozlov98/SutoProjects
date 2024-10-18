using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterTask3
{
    public sealed class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        private IDisposable _disposable;

        public void Show(IPresenter args)
        {
            if (args is not ICharacterPresenter characterPresenter) return;

            _nameText.text = characterPresenter.Name;
            _icon.sprite = characterPresenter.Icon;

            _disposable = characterPresenter.SelectCommand.BindTo(_button);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}
