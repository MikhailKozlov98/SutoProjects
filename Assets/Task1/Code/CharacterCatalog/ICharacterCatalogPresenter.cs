using System.Collections.Generic;
using UniRx;

namespace CharacterTask1
{
    public interface ICharacterCatalogPresenter : IPresenter
    {
        IReadOnlyList<ICharacterPresenter> CharacterPresenters { get; }
        ReactiveCommand SelectCommand { get; }
        ReactiveCommand FlipCommandRight { get; }
        ReactiveCommand FlipCommandLeft { get; }
        CharacterPresenter SelectedCharacter { get; }
    }
}
