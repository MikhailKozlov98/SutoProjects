using System.Collections.Generic;
using UniRx;

namespace CharacterTask1
{
    public sealed class CharacterCatalogPresenter : ICharacterCatalogPresenter
    {
        public ReactiveCommand SelectCommand { get; }
        public ReactiveCommand FlipCommandRight { get; }
        public ReactiveCommand FlipCommandLeft { get; }
        public IReadOnlyList<ICharacterPresenter> CharacterPresenters => _presenters;
        private readonly List<ICharacterPresenter> _presenters = new();

        public CharacterPresenter SelectedCharacter => _selectedCharacter;
        private CharacterPresenter _selectedCharacter;
        private sbyte _currentCharacterSelectedIndex = 1;
        private readonly CharacterSelector _characterSelector;
        private readonly CompositeDisposable _disposables = new();

        public CharacterCatalogPresenter(CharacterCatalog characterCatalog, CharacterPresenterFactory factory,
            CharacterSelector characterSelector)
        {
            _characterSelector = characterSelector;

            CharacterData[] characters = characterCatalog.Characters;
            for (int i = 0; i < characters.Length; i++)
            {
                CharacterData character = characters[i];
                CharacterPresenter characterPresenter = factory.Create(character);
                _presenters.Add(characterPresenter);
            }

            _selectedCharacter = (CharacterPresenter)_presenters[_currentCharacterSelectedIndex];

            SelectCommand = new ReactiveCommand();
            SelectCommand.Subscribe(OnSelectCommand).AddTo(_disposables);

            FlipCommandRight = new ReactiveCommand();
            FlipCommandLeft = new ReactiveCommand();

            FlipCommandRight.Subscribe(OnRightFlipCommand).AddTo(_disposables);
            FlipCommandLeft.Subscribe(OnLeftFlipCommand).AddTo(_disposables);
        }

        private void OnRightFlipCommand(Unit unit)
        {
            FlipRight();
        }

        private void OnLeftFlipCommand(Unit unit)
        {
            FlipLeft();
        }

        private void FlipRight()
        {
            _currentCharacterSelectedIndex++;
            if (_currentCharacterSelectedIndex > _presenters.Count - 1)
            {
                _currentCharacterSelectedIndex = 0;
            }
            _selectedCharacter = (CharacterPresenter)_presenters[_currentCharacterSelectedIndex];
        }

        private void FlipLeft()
        {
            _currentCharacterSelectedIndex--;
            if (_currentCharacterSelectedIndex < 0)
            {
                _currentCharacterSelectedIndex = (sbyte)(_presenters.Count - 1);
            }
            _selectedCharacter = (CharacterPresenter)_presenters[_currentCharacterSelectedIndex];
        }

        private void OnSelectCommand(Unit unit)
        {
            _characterSelector.Select(SelectedCharacter);
        }

        ~CharacterCatalogPresenter()
        {
            _disposables.Dispose();
        }
    }
}
