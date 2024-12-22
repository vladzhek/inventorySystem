using System;
using Core.Backpack;
using Core.Items;
using Networking;
using Services;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        
        [SerializeField] public BackpackUI BackpackUI;
        [SerializeField] public PointerUpHandler PointerUpHandler;
        
        public DOTWeenService DOTWeenService = new();
        public ServerManager ServerManager = new();
        
        public event Action<Item> OnItemTake;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void OpenCloseBackpackUI(bool isActive)
        {
            BackpackUI.gameObject.SetActive(isActive);
        }

        public void OnItemTakeInvoke(Item item)
        {
            OnItemTake?.Invoke(item);
        }
    }
}