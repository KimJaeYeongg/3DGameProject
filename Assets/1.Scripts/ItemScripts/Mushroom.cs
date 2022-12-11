using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Item
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
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log(collision.gameObject.transform.name);
            
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.position -= new Vector3(0, 0.1f, 0);
        }
    }
}
