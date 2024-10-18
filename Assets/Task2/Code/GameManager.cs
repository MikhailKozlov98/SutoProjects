using CharacterTask1;
using UnityEngine;
using Zenject;

namespace CharacterTask2
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
            ShowCharacterPopup();
        }

        private void ShowCharacterPopup()
        {
            _characterCatalogPopup.FirstShow(new CharacterCatalogPresenter(_characterCatalog, _characterPresenterFactory));
        }
    }
}
