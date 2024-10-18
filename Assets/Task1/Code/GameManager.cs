using UnityEngine;
using Zenject;

namespace CharacterTask1
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterCatalogPopup _characterCatalogPopup;
        [SerializeField] private CharacterCatalog _characterCatalog;
        private CharacterPresenterFactory _characterPresenterFactory;
        private CharacterSelector _characterSelector;

        [Inject]
        private void Construct(CharacterPresenterFactory characterPresenterFactory, CharacterSelector characterSelector)
        {
            _characterPresenterFactory = characterPresenterFactory;
            _characterSelector = characterSelector;
        }

        private void Start()
        {
            ShowCharacterCatalog();
        }

        private void ShowCharacterCatalog()
        {
            _characterCatalogPopup.Show(new CharacterCatalogPresenter(
                _characterCatalog, _characterPresenterFactory, _characterSelector));
        }
    }
}
