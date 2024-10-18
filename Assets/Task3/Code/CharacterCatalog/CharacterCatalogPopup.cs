using System;
using UnityEngine;
using UniRx;

namespace CharacterTask3
{
    public class CharacterCatalogPopup : MonoBehaviour
    {
        [SerializeField] private CharacterPopup[] _characterPopups;
        [SerializeField] private CharacterSelectedPopup _characterSelectedPopup;

        private IDisposable _disposable;

        public void Show(IPresenter args)
        {
            if (args is not CharacterCatalogPresenter catalogPresenter) return;

            for (int i = 0; i < catalogPresenter.CharacterPresenters.Count; i++)
            {
                ICharacterPresenter characterPresenter = catalogPresenter.CharacterPresenters[i];
                _characterPopups[i].Show(characterPresenter);
            }

            _disposable = catalogPresenter.SelectedCharacter.SkipLatestValueOnSubscribe().Subscribe(OnSelectedCharacter);
        }

        private void OnSelectedCharacter(CharacterPresenter presenter)
        {
            _characterSelectedPopup.Show(presenter.Icon);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}
