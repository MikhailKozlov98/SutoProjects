using CharacterTask1;

namespace CharacterTask2
{
    public sealed class CharacterPresenterFactory
    {
        public CharacterPresenter Create(CharacterData characterData)
        {
            return new CharacterPresenter(characterData);
        }
    }
}