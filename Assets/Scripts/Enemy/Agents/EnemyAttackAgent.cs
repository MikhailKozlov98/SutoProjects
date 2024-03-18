using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public delegate void EnemyFireHandler(GameObject enemy, Vector2 position, Vector2 direction, BulletConfig bulletConfig);

        public event EnemyFireHandler OnFire;

        [SerializeField] private EnemyCharacter _enemyCharacter;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private float _countdown;

        private Character _target;
        private float _currentTime;

        internal void SetTarget(Character target)
        {
            this._target = target;
        }

        public void Reset()
        {
            this._currentTime = this._countdown;
        }

        private void FixedUpdate()
        {
            if (!this._enemyCharacter.IsReached())
            {
                return;
            }

            if (!this._target.GetHpComponent().IsHitPointsExists())
            {
                return;
            }

            this._currentTime -= Time.fixedDeltaTime;
            if (this._currentTime <= 0)
            {
                this.Fire();
                this._currentTime += this._countdown;
            }
        }

        private void Fire()
        {
            var startPosition = this._enemyCharacter.GetWeaponPosition();
            var vector = (Vector2)this._target.transform.position - startPosition;
            var direction = vector.normalized;
            this.OnFire?.Invoke(this.gameObject, startPosition, direction, _bulletConfig);
        }
    }
}