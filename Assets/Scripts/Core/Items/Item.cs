using System;
using Interaction;
using UnityEngine;

namespace Core.Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] public DragHandler DragHandler;
        
        [SerializeField] private string _name;
        [SerializeField] private float _weight;
        [SerializeField] private ItemType _type;
        [SerializeField] private Sprite _icon;

        public string ID
        {
            get { return _type + _name; } 
        }
        public string name => _name;
        public float Weight => _weight;
        public ItemType Type => _type;
        public Sprite Icon => _icon;

        public bool isEnableObject = true;

        private Rigidbody _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void KineticActive(bool isActive)
        {
            _rb.isKinematic = isActive;
        }

        public void EnableItem()
        {
            isEnableObject = true;
        }

        public void DisableItem()
        {
            isEnableObject = false;
            DragHandler.StopDragging();
        }
    }
}