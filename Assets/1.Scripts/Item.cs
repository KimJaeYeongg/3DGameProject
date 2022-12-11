using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    public GameObject ItemObject;

    public void CreateObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Vector3 hitPos = hit.point;
            
            CreateInstance(hitPos);
        }
    }

    public string GetItemName() { return itemName; }

    protected abstract void CreateInstance(Vector3 hitPos);
}
