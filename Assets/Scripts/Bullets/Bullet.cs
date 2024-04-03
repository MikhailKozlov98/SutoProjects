using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, GameObject> OnCollisionEntered;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private bool _isPlayer;
        internal bool IsPlayer => _isPlayer;
        private int _damage;
        internal int Damage => _damage;

        private void OnEnable()
        {
            OnCollisionEntered += DealDamage;
        }

        private void OnDisable()
        {
            OnCollisionEntered -= DealDamage;
        }

        internal void Initialize(BulletSystem.Args args)
        {
            _rigidbody2D.velocity = args.Velocity;
            _isPlayer = args.IsPlayer;
            _damage = args.Damage;
            gameObject.layer = args.PhysicsLayer;
            transform.position = args.StartPosition;
            _spriteRenderer.color = args.Color;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
                OnCollisionEntered?.Invoke(this, collision.gameObject);
        }

        internal static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }
    }
}