using UnityEngine;

namespace ShootEmUp
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _playerCharacter;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private LevelBounds _levelBounds;

        // private void OnEnable()
        // {
        //     _inputManager.OnMove += GetHorizontalDirection;
        //     _inputManager.OnFire += IsFireRequired;
        // }

        // private void OnDisable()
        // {
        //     _inputManager.OnMove -= GetHorizontalDirection;
        //     _inputManager.OnFire -= IsFireRequired;
        // }

        private void FixedUpdate()
        {
            if (this._levelBounds.InBounds(_playerCharacter.transform.position))
            {
                this._playerCharacter.Move(new Vector2(this._inputManager.GetHorizontalDirection(), 0F) * Time.fixedDeltaTime);
            }
            else
            {
                _playerCharacter.transform.position = _levelBounds.SetCenterPosition();
            }
        }
    }
}
