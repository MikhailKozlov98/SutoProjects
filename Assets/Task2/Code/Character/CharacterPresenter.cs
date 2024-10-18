using CharacterTask1;
using UniRx;
using UnityEngine;

namespace CharacterTask2
{
    public sealed class CharacterPresenter : ICharacterPresenter
    {
        public string Name { get; }
        public int MaxHealth { get; }
        public IReadOnlyReactiveProperty<int> Health => _health;
        private readonly ReactiveProperty<int> _health = new();
        public IReadOnlyReactiveProperty<float> HealthShare => _healthShare;
        private readonly ReactiveProperty<float> _healthShare = new();

        public ReactiveProperty<bool> IsDead => _isDead;
        private readonly ReactiveProperty<bool> _isDead = new();

        public CharacterPresenter(CharacterData data)
        {
            Name = data.Name;
            MaxHealth = data.Health;
            _health.Value = data.Health;
            _healthShare.Value = 1F;
        }

        public void TakeDamage()
        {
            int damge = Random.Range(20, 41);
            _health.Value -= damge;
            _healthShare.Value = (float)Health.Value / MaxHealth;

            if (Health.Value <= 0)
            {
                _health.Value = MaxHealth;
                _healthShare.Value = 1F;
                _isDead.Value = true;
            }
        }
    }
}