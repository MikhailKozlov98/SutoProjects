using System.Collections.Generic;
using UniRx;

namespace CharacterTask2
{
    public interface ICharacterCatalogPresenter : IPresenter
    {
        IReadOnlyList<ICharacterPresenter> CharacterPresenters { get; }
        ReactiveCommand DamageCommand { get; }
        IReadOnlyReactiveProperty<CharacterPresenter> SelectedCharacter { get; }
    }
}