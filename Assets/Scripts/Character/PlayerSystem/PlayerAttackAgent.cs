using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerAttackAgent : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _playerCharacter;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private BulletConfig _bulletConfig;

        public delegate void PlayerFireHandler(BulletConfig bulletConfig);

        public event PlayerFireHandler OnPlayerFire;

        private void Update()
        {
            if (this._inputManager.IsFireRequired())
            {
                OnPlayerFire?.Invoke(_bulletConfig);
            }
        }
    }
}