using CharacterTask1;
using UnityEngine;
using Zenject;

namespace CharacterTask3
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterCatalogPopup _characterCatalogPopup;
        [SerializeField] private CharacterCatalog _characterCatalog;
        private CharacterPresenterFactory _characterPresenterFactory;

        [Inject]
        private void Construct(CharacterPresenterFactory characterPresenterFactory)
        {
            _characterPresenterFactory = characterPresenterFactory;
        }

        private void Start()
        {
            ShowCharacterCatalog();
        }

        private void ShowCharacterCatalog()
        {
            _characterCatalogPopup.Show(new CharacterCatalogPresenter(
                _characterCatalog, _characterPresenterFactory));
        }
    }
}