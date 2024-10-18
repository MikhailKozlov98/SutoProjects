using System.Collections.Generic;
using CharacterTask1;
using UniRx;

namespace CharacterTask3
{
    public sealed class CharacterCatalogPresenter : ICharacterCatalogPresenter
    {
        public IReadOnlyList<ICharacterPresenter> CharacterPresenters => _presenters;
        private readonly List<ICharacterPresenter> _presenters = new();

        public ReactiveProperty<CharacterPresenter> SelectedCharacter { get; set; }

        public CharacterCatalogPresenter(CharacterCatalog characterCatalog, CharacterPresenterFactory factory)
        {
            SelectedCharacter = new();

            CharacterData[] characterDatas = characterCatalog.Characters;
            for (int i = 0; i < characterDatas.Length; i++)
            {
                CharacterData characterData = characterDatas[i];
                CharacterPresenter characterPresenter = factory.Create(characterData);
                _presenters.Add(characterPresenter);

                characterPresenter.CatalogPresenter = this;
            }
        }
    }
}