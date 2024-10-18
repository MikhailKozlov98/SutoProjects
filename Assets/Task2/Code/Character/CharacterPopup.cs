using TMPro;
using UnityEngine;

namespace CharacterTask2
{
    public sealed class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private RectTransform _barTransform;

        private readonly float _startWidth = 500F;

        public void Show(IPresenter args)
        {
            if (args is not ICharacterPresenter characterPresenter) return;

            gameObject.SetActive(true);

            _nameText.text = characterPresenter.Name;

            // Как получить значения сразу строкой, а не обращаться к полю?
            _healthText.text = $"Health: {characterPresenter.Health.Value}";
            _barTransform.sizeDelta = new Vector2(characterPresenter.HealthShare.Value * _startWidth, 100F);
        }

        public void UpdateHealth(int health)
        {
            _healthText.text = $"Health: {health}";
        }

        public void UpdateHealthBar(float healthShare)
        {
            _barTransform.sizeDelta = new Vector2(healthShare * _startWidth, 100F);
        }
    }
}