using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Item
{
    protected override void CreateInstance(Vector3 hitPos)
    {
        GameObject item = Instantiate(ItemObject);
        item.transform.position = hitPos;
        item.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log(collision.gameObject.transform.name);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.position -= new Vector3(0, 0.1f, 0);
        }
    }
}
