using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached
        {
            get { return this._isReached; }
        }

        [SerializeField] private EnemyCharacter _enemyCharacter;

        private Vector2 _destination;

        private bool _isReached;

        public void SetDestination(Vector2 endPoint)
        {
            this._destination = endPoint;
            this._isReached = false;
        }

        private void FixedUpdate()
        {
            if (this._isReached)
            {
                return;
            }
            
            Vector2 vector = this._destination - (Vector2) this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this._isReached = true;
                return;
            }

            Vector2 direction = vector.normalized * Time.fixedDeltaTime;
            this._enemyCharacter.Move(direction);
        }
    }
}