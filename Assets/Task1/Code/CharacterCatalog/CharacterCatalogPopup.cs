using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System.Collections.Generic;

namespace CharacterTask1
{
    public sealed class CharacterCatalogPopup : MonoBehaviour
    {
        [SerializeField] private CharacterPopup[] _characterPopups;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _flipButtonRight;
        [SerializeField] private Button _flipButtonLeft;

        private IReadOnlyList<ICharacterPresenter> _characterPresenters;
        private sbyte _currentCharacterSelectedIndex = 0;
        private readonly CompositeDisposable _disposables = new();

        public void Show(IPresenter args)
        {
            if (args is not ICharacterCatalogPresenter presenter) return;

            _characterPresenters = presenter.CharacterPresenters;

            gameObject.SetActive(true);

            for (int i = 0; i < _characterPopups.Length; i++)
            {
                ICharacterPresenter characterPresenter = presenter.CharacterPresenters[i];
                _characterPopups[i].Show(characterPresenter);
            }

            presenter.SelectCommand.BindTo(_selectButton).AddTo(_disposables);

            presenter.FlipCommandRight.BindTo(_flipButtonRight).AddTo(_disposables);
            presenter.FlipCommandLeft.BindTo(_flipButtonLeft).AddTo(_disposables);

            _flipButtonRight.onClick.AddListener(FlipRight);
            _flipButtonLeft.onClick.AddListener(FlipLeft);
        }

        private void FlipRight()
        {
            _currentCharacterSelectedIndex++;
            if (_currentCharacterSelectedIndex > _characterPresenters.Count - 1)
            {
                _currentCharacterSelectedIndex = 0;
            }
            FlipPopup();
        }

        private void FlipLeft()
        {
            _currentCharacterSelectedIndex--;
            if (_currentCharacterSelectedIndex < 0)
            {
                _currentCharacterSelectedIndex = (sbyte)(_characterPresenters.Count - 1);
            }
            FlipPopup();
        }

        private void FlipPopup()
        {
            sbyte index = _currentCharacterSelectedIndex;
            for (int i = 0; i < _characterPopups.Length; i++)
            {
                ICharacterPresenter characterPresenter = _characterPresenters[index];
                _characterPopups[i].Show(characterPresenter);

                index++;
                if (index > _characterPresenters.Count - 1)
                {
                    index = 0;
                }
            }
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
            _flipButtonRight.onClick.RemoveListener(FlipRight);
            _flipButtonLeft.onClick.RemoveListener(FlipLeft);
        }
    }
}
