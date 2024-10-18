using System.Collections.Generic;
using UniRx;

namespace CharacterTask3
{
    public interface ICharacterCatalogPresenter : IPresenter
    {
        IReadOnlyList<ICharacterPresenter> CharacterPresenters { get; }
        ReactiveProperty<CharacterPresenter> SelectedCharacter { get; }
    }
}