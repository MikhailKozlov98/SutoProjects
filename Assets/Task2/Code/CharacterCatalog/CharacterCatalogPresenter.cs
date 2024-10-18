using UnityEngine;
using System.Collections.Generic;
using CharacterTask1;
using UniRx;

namespace CharacterTask2
{
    public sealed class CharacterCatalogPresenter : ICharacterCatalogPresenter
    {
        public IReadOnlyList<ICharacterPresenter> CharacterPresenters => _presenters;
        private readonly List<ICharacterPresenter> _presenters = new();

        public ReactiveCommand DamageCommand { get; }
        public IReadOnlyReactiveProperty<CharacterPresenter> SelectedCharacter => _selectedCharacter;
        private readonly ReactiveProperty<CharacterPresenter> _selectedCharacter = new();

        private readonly CompositeDisposable _disposables = new();

        public CharacterCatalogPresenter(CharacterCatalog characterCatalog, CharacterPresenterFactory factory)
        {
            CharacterData[] characters = characterCatalog.Characters;
            for (int i = 0; i < characters.Length; i++)
            {
                CharacterData character = characters[i];
                CharacterPresenter presenter = factory.Create(character);
                if (i == 0) _selectedCharacter.Value = presenter;

                presenter.IsDead.SkipLatestValueOnSubscribe().Subscribe(ShowNewCharacter).AddTo(_disposables);

                _presenters.Add(presenter);
            }

            DamageCommand = new ReactiveCommand();
            DamageCommand.Subscribe(OnDamaged).AddTo(_disposables);
        }

        private void ShowNewCharacter(bool obj)
        {
            SelectedCharacter.Value.IsDead.Value = false;
            _selectedCharacter.Value = (CharacterPresenter)_presenters[Random.Range(0, _presenters.Count)];
        }

        private void OnDamaged(Unit unit)
        {
            SelectedCharacter.Value.TakeDamage();
        }

        ~CharacterCatalogPresenter()
        {
            _disposables.Dispose();
        }
    }
}