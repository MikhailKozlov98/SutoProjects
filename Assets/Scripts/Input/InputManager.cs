using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public event Action<float> OnMove;
        public event Action OnFire;

        // private void OnEnable()
        // {
        //     OnMove += GetHorizontalDirection;
        //     OnFire += IsFireRequired;
        // }

        // private void OnDisable()
        // {
        //     OnMove -= GetHorizontalDirection;
        //     OnFire -= IsFireRequired;
        // }

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