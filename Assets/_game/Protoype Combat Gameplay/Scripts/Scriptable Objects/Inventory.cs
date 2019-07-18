using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> items = new List<InventorySlot>();

    public InventorySlot this[int _key]
    {
        get
        {
            return items[_key];
        }
        private set { }
    }

    public void Consume(int _id)
    {
        items[_id].quantity--;
        if(items[_id].quantity <= 0)
        {
            items.RemoveAt(_id);
        }
    }

    public int Count
    {
        get
        {
            if (items == null)
                return 0;

            return items.Count;
        }
        private set { }
    }

    public class InventorySlot
    {
        public InventorySlot()
        {
            item = new Item();
            quantity = 1;
        }

        public Item item;
        public int quantity;
    }
}
