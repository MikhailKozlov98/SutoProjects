using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "Bullets/New BulletConfig"
    )]
    public sealed class BulletConfig : ScriptableObject
    {
        [SerializeField] private PhysicsLayer _physicsLayer;
        internal PhysicsLayer PhysicsLayer => _physicsLayer;

        [SerializeField] private Color _color;
        internal Color Color => _color;

        [SerializeField] private int _damage;
        internal int Damage => _damage;

        [SerializeField] private float _speed;
        internal float Speed => _speed;

        [SerializeField] private bool _isPlayer;
        internal bool IsPlayer => _isPlayer;
    }
}