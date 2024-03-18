using UnityEngine;

namespace ShootEmUp
{
    internal class PlayerCharacter : Character
    {
        [SerializeField] private PlayerAttackAgent _playerAttackAgent;

        internal PlayerAttackAgent GetPlayerAttack()
        {
            return _playerAttackAgent;
        }
    }
}
