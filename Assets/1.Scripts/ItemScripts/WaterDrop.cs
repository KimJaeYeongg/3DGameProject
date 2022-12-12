using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : Item
{

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void CreateInstance(Vector3 hitPos)
    {
        rb.constraints = ~RigidbodyConstraints.FreezePositionY;
        GameObject item = Instantiate(ItemObject);
        item.transform.position = hitPos;
        item.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
