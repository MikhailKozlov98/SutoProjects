using System;
using CharacterTask1;
using UniRx;
using UnityEngine;

namespace CharacterTask3
{
    public sealed class CharacterPresenter : ICharacterPresenter
    {
        public string Name { get; }
        public Sprite Icon { get; }
        public ReactiveCommand SelectCommand { get; }

        public CharacterCatalogPresenter CatalogPresenter { get; set; }

        private readonly IDisposable _disposable;

        public CharacterPresenter(CharacterData characterData)
        {
            Name = characterData.Name;
            Icon = characterData.Icon;

            SelectCommand = new ReactiveCommand();
            _disposable = SelectCommand.Subscribe(OnSelectedCharacter);
        }

        private void OnSelectedCharacter(Unit unit)
        {
            CatalogPresenter.SelectedCharacter.Value = this;
        }
        
        ~CharacterPresenter()
        {
            _disposable.Dispose();
        }
    }
}
