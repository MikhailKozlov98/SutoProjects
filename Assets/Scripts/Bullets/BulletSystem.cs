using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int _initialCount = 50;

        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _levelBounds;

        private GameObjectPool<Bullet> _pool;
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();

        private void Awake()
        {
            // for (var i = 0; i < this._initialCount; i++)
            // {
            //     var bullet = Instantiate(this._prefab, this._container);
            //     this.m_bulletPool.Enqueue(bullet);
            // }
            _pool = new GameObjectPool<Bullet>(_prefab);
        }

        private void FixedUpdate()
        {
            m_cache.Clear();
            m_cache.AddRange(this.m_activeBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++)
            {
                var bullet = this.m_cache[i];
                if (!this._levelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void CreateBullet(BulletConfig bulletConfig, Vector2 startPosition, Vector2 direction)
        {
            Bullet bullet = _pool.Create(_worldTransform);

            Args args = new Args
            {
                IsPlayer = bulletConfig.IsPlayer,
                PhysicsLayer = (int)bulletConfig.PhysicsLayer,
                Color = bulletConfig.Color,
                Damage = bulletConfig.Damage,
                StartPosition = startPosition,
                Velocity = direction
            };

            bullet.Initialize(args);

            if (this.m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletDestroy;
            }
        }

        private void OnBulletDestroy(Bullet bullet, GameObject gameObject)
        {
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (this.m_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= this.OnBulletDestroy;
                _pool.Despawn(bullet, _container);
                // this.m_bulletPool.Enqueue(bullet);
            }
        }

        public struct Args
        {
            public Vector2 StartPosition;
            public Vector2 Velocity;
            public Color Color;
            public int PhysicsLayer;
            public int Damage;
            public bool IsPlayer;
        }
    }
}