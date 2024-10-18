using CharacterTask1;

namespace CharacterTask3
{
    public sealed class CharacterPresenterFactory
    {
        public CharacterPresenter Create(CharacterData characterData)
        {
            return new CharacterPresenter(characterData);
        }
    }

}