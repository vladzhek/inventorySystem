using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services
{
    public class PointerUpHandler : MonoBehaviour
    {
        public event Action OnMouseUp;
        private bool isPointerDownOutside = false;

        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnMouseUp?.Invoke();
            }
        }
    }
}