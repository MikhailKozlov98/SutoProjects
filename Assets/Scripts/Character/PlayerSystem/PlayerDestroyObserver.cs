using UnityEngine;

namespace ShootEmUp
{
    public class PlayerDestroyObserver : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _playerCharacter;
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _playerCharacter.GetHpComponent().HpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this._playerCharacter.GetHpComponent().HpEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => this._gameManager.FinishGame();
    }
}
