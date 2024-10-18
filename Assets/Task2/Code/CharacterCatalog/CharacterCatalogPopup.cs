using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterTask2
{
    public sealed class CharacterCatalogPopup : MonoBehaviour
    {
        [SerializeField] private CharacterPopup _characterPopup;
        [SerializeField] private Button _damageButton;

        private readonly CompositeDisposable _disposables = new();

        public void FirstShow(IPresenter args)
        {
            if (args is not ICharacterCatalogPresenter catalogPresenter) return;

            ShowNewCharacter(catalogPresenter.CharacterPresenters[0]);

            catalogPresenter.DamageCommand.BindTo(_damageButton).AddTo(_disposables);
            catalogPresenter.SelectedCharacter.Subscribe(ShowNewCharacter).AddTo(_disposables);
        }

        private void UpdateHealthText(int health)
        {
            _characterPopup.UpdateHealth(health);
        }

        private void UpdateHealthBar(float healthShare)
        {
            _characterPopup.UpdateHealthBar(healthShare);
        }

        private void ShowNewCharacter(ICharacterPresenter characterPresenter)
        {
            _characterPopup.Show(characterPresenter);

            characterPresenter.Health.Subscribe(UpdateHealthText).AddTo(_disposables);
            characterPresenter.HealthShare.Subscribe(UpdateHealthBar).AddTo(_disposables);
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}
