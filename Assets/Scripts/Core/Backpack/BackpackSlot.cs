using Core.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Backpack
{
    public class BackpackSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("UI Elements")]
        [SerializeField] private Image itemIcon; // Иконка предмета в слоте

        private Item _item;
        public void Setup(Item item)
        {
            if (itemIcon != null)
            {
                _item = item;
                itemIcon.sprite = item.Icon;
            }
        }

        public void CloseBackpack()
        {
            GameController.Instance.OpenCloseBackpackUI(false);
            GameController.Instance.OnItemTakeInvoke(_item);
            _item.EnableItem();
            _item.DragHandler.DraggingObject();
            GameController.Instance.PointerUpHandler.OnMouseUp -= CloseBackpack;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            GameController.Instance.PointerUpHandler.OnMouseUp += CloseBackpack;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GameController.Instance.PointerUpHandler.OnMouseUp -= CloseBackpack;
        }
    }
}