using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotObject
{
    public GameObject slotObject1;
    public GameObject slotObject2;
    public GameObject slotObject3;
    public GameObject slotObject4;
    public GameObject slotObject5;
}

[System.Serializable]
public class Slot
{
    public ItemSlot slot1;
    public ItemSlot slot2;
    public ItemSlot slot3;
    public ItemSlot slot4;
    public ItemSlot slot5;
}

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item> ();

    public SlotObject inventorySlotObject;
    public Slot inventorySlot;

    public int space = 5;

    public bool AddItem(Item item)
    {
        if (items.Count < space)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetItemName() == item.GetItemName())
                    return false;

            }

            items.Add(item);
            switch (items.Count)
            {
                case 1:
                    inventorySlotObject.slotObject1.SetActive(true);
                    inventorySlot.slot1 = inventorySlotObject.slotObject1.GetComponent<ItemSlot> ();
                    inventorySlot.slot1.SetMyItem(item, 1);
                    break;
                case 2:
                    inventorySlotObject.slotObject2.SetActive(true);
                    inventorySlot.slot2 = inventorySlotObject.slotObject2.GetComponent<ItemSlot>();
                    inventorySlot.slot2.SetMyItem(item, 2);
                    break;
                case 3:
                    inventorySlotObject.slotObject3.SetActive(true);
                    inventorySlot.slot3 = inventorySlotObject.slotObject3.GetComponent<ItemSlot>();
                    inventorySlot.slot3.SetMyItem(item, 3);
                    break;
                case 4:
                    inventorySlotObject.slotObject4.SetActive(true);
                    inventorySlot.slot4 = inventorySlotObject.slotObject4.GetComponent<ItemSlot>();
                    inventorySlot.slot4.SetMyItem(item, 4);
                    break;
                case 5:
                    inventorySlotObject.slotObject5.SetActive(true);
                    inventorySlot.slot5 = inventorySlotObject.slotObject5.GetComponent<ItemSlot>();
                    inventorySlot.slot5.SetMyItem(item, 5);
                    break;
            }
            
            Debug.Log("Item added: " + item.GetItemName());
        }
        return true;
    }

    public Item GetItem(int num) { return items[num]; }
}
