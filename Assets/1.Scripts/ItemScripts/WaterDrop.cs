using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : Item
{
    protected override void CreateInstance(Vector3 hitPos)
    {
        GameObject item = Instantiate(ItemObject);
        item.transform.position = hitPos;
        item.SetActive(true);
    }
}
