using UnityEngine;

namespace ShootEmUp
{
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _playerCharacter;

        [SerializeField] private BulletSystem _bulletSystem;

        private void OnEnable()
        {
            _playerCharacter.GetPlayerAttack().OnPlayerFire += this.OnFlyBullet;
        }

        private void OnDisable()
        {
            this._playerCharacter.GetPlayerAttack().OnPlayerFire -= this.OnFlyBullet;
        }

        private void OnFlyBullet(BulletConfig bulletConfig)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = this._playerCharacter.GetWeaponPosition(),
                velocity = this._playerCharacter.GetWeaponRotation() * Vector3.up * bulletConfig.speed
            });
        }

    }
}
