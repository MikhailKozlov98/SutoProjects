using UnityEngine;

namespace ShootEmUp
{
    internal class Character : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private WeaponComponent _weaponComponent;

        internal void Move(Vector2 direction)
        {
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }

        internal HitPointsComponent GetHpComponent()
        {
            return _hitPointsComponent;
        }

        internal Vector2 GetWeaponPosition()
        {
            return _weaponComponent.Position;
        }

        internal Quaternion GetWeaponRotation()
        {
            return _weaponComponent.Rotation;
        }
    }
}
