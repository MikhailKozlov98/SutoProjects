using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        private bool _fireRequired;
        internal bool FireRequired => _fireRequired;

        internal float GetHorizontalDirection()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return -1F;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                return 1F;
            }
            else
            {
                return 0F;
            }
        }

        internal bool IsFireRequired()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                return true;
            }
            return false;
        }
    }
}