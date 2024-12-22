using Core.Items;
using UnityEngine;

namespace Core.Backpack
{
    public class BackpackZone : MonoBehaviour
    {
        [SerializeField] private Backpack _backpack;

        private void OnTriggerEnter(Collider other)
        {
            var item = other.GetComponent<Item>();
            if (item != null)
            {
                _backpack.AddItem(item, other.gameObject);
            }
        }
    }
}