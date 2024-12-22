using System;
using Core;
using Core.Items;
using UnityEngine;

namespace Interaction
{
    public class DragHandler : MonoBehaviour
    {
        [SerializeField] private Item _item;
        
        private Camera _mainCamera;
        private Vector3 _offset; // Смещение между мышью и объектом
        private bool _isDragging; 

        public void DraggingObject()
        {
            if(!_item.isEnableObject) return;
            
            transform.position = GetMouseWorldPosition();
            _offset = transform.position - GetMouseWorldPosition();
            _isDragging = true;
        }
        
        public void StopDragging()
        {
            _isDragging = false;
        }

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            if(!_item.isEnableObject) return;
            _item.KineticActive(true);
            DraggingObject();
        }

        private void Update()
        {
            if (_isDragging)
            {
                transform.position = GetMouseWorldPosition() + _offset;
            }
        }

        private void OnMouseUp()
        {
            StopDragging();
            
            if(!_item.isEnableObject) return;
            _item.KineticActive(false);
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = _mainCamera.WorldToScreenPoint(transform.position).z; // Глубина (Z)
            return _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        }
    }
}