using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerAttackAgent : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _playerCharacter;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private BulletSystem _bulletSystem;


        private void Update()
        {
            if (_inputManager.IsFireRequired())
            {
                Fire();
            }
        }

        private void Fire()
        {
            Vector2 startPosition = _playerCharacter.GetWeaponPosition();

            Vector2 direction = _playerCharacter.GetWeaponRotation() * Vector3.up * _bulletConfig.Speed;

            _bulletSystem.CreateBullet(_bulletConfig, startPosition, direction);
        }
    }
}