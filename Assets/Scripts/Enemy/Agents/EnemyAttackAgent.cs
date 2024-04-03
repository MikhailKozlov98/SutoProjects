using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private EnemyCharacter _enemyCharacter;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private float _countdown;

        private Character _target;
        private BulletSystem _bulletSystem;
        private float _currentTime;

        internal void SetTarget(Character target)
        {
            _target = target;
        }

        internal void SetBulletSystem(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        private void FixedUpdate()
        {
            if (!_enemyCharacter.IsReached())
            {
                return;
            }

            if (!_target.GetHpComponent().IsHitPointsExists())
            {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            Vector2 startPosition = _enemyCharacter.GetWeaponPosition();

            Vector2 vector = (Vector2)_target.transform.position - startPosition;
            Vector2 direction = vector.normalized * 2F;

            _bulletSystem.CreateBullet(_bulletConfig, startPosition, direction);
        }
    }
}