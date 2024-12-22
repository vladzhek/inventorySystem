using System;
using System.Collections.Generic;
using Core.Items;
using Networking;
using UnityEngine;

namespace Core.Backpack
{
    public class Backpack : MonoBehaviour
    {
        [NonSerialized] public Dictionary<string, Item> Items = new(); // Список предметов в рюкзаке
        [SerializeField] private List<Transform> _itemsPos = new List<Transform>();
        [SerializeField] private BackpackUI _backpackUI;

        public event Action<Item> ItemAdded; 
        public event Action<Item> ItemRemoved;

        private void OnEnable()
        {
            GameController.Instance.OnItemTake += CLoseBackpack;
        }

        private void OnDisable()
        {
            GameController.Instance.OnItemTake -= CLoseBackpack;
        }

        private void CLoseBackpack(Item item)
        {
            RemoveItem(item);
            GameController.Instance.OpenCloseBackpackUI(false);
        }

        private void Start()
        {
            _backpackUI.gameObject.SetActive(false);
        }

        public void AddItem(Item item, GameObject itemObject)
        {
            if(Items.ContainsKey(item.ID)) return;
                
            Items.Add(item.ID,item);
            item.DisableItem();
            ChoicePos(itemObject, item.Type);

            ItemAdded?.Invoke(item);
        }
        
        public void RemoveItem(Item item)
        {
            if (Items.Remove(item.ID))
            {
                ItemRemoved?.Invoke(item);
                item.EnableItem();
                GameController.Instance.ServerManager.SendItemEvent(item.ID, "removed");
            }
        }

        private void ChoicePos(GameObject go, ItemType type)
        {
            switch (type)
            {
                case ItemType.Weapon:
                    GameController.Instance.DOTWeenService.Snaping(go.transform, _itemsPos[0], 0.2f);
                    break;
                case ItemType.Food:
                    GameController.Instance.DOTWeenService.Snaping(go.transform, _itemsPos[1], 0.2f);
                    break;
                case ItemType.Tool:
                    GameController.Instance.DOTWeenService.Snaping(go.transform, _itemsPos[2], 0.2f);
                    break;
            }
        }

        private void OnMouseDown()
        {
            _backpackUI.gameObject.SetActive(true);
        }
    }
}