using System.Collections.Generic;
using Core.Items;
using UnityEngine;

namespace Core.Backpack
{
    public class BackpackUI : MonoBehaviour
    {
        [Header("UI Elements")] [SerializeField]
        private Transform slotsContainer; // Контейнер для слотов

        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private Backpack _backpack;
        
        private List<BackpackSlot> _slots = new ();

        private void OnEnable()
        {
            InitializeUI();
        }

        private void Start()
        {
            InitializeUI();
        }
        
        private void InitializeUI()
        {
            foreach (Transform child in slotsContainer)
            {
                Destroy(child.gameObject); 
            }

            foreach (var itemConfig in _backpack.Items)
            {
                AddSlot(itemConfig.Value);
            }
        }
        
        private void AddSlot(Item item)
        {
            GameObject slotObject = Instantiate(slotPrefab, slotsContainer);
            BackpackSlot slot = slotObject.GetComponent<BackpackSlot>();
            if (slot != null)
            {
                slot.Setup(item);
                _slots.Add(slot);
            }
        }
    }
}