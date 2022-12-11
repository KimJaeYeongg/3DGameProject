using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Item myItem;
    Vector3 originPos;

    // Start is called before the first frame update
    public void SetMyItem(Item item, int pos)
    {
        myItem = item;
        if (myItem.GetItemName() == "Rock")
        {
            GameObject.Find("RockShowing").GetComponent<UpdateItemPos>().notify(pos);
        }
        else if (myItem.GetItemName() == "Mushroom")
        {
            GameObject.Find("MushroomShowing").GetComponent<UpdateItemPos>().notify(pos);
        }
        else if (myItem.GetItemName() == "WaterDrop")
        {
            GameObject.Find("WaterDropShowing").GetComponent<UpdateItemPos>().notify(pos);
        }
        else if (myItem.GetItemName() == "Cloud")
        {
            GameObject.Find("CloudShowing").GetComponent<UpdateItemPos>().notify(pos);
        }
        else if (myItem.GetItemName() == "Bush")
        {
            GameObject.Find("BushShowing").GetComponent<UpdateItemPos>().notify(pos);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        myItem.CreateObject();
        transform.position = originPos;
    }
}
