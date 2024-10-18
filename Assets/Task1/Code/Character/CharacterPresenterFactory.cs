namespace CharacterTask1
{
    public sealed class CharacterPresenterFactory
    {
        public CharacterPresenter Create(CharacterData characterData)
        {
            return new CharacterPresenter(characterData);
        }
    }
}
