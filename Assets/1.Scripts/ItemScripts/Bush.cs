using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : Item
{
    private int waternum = 0;
    private bool waterbool = false;
    private static bool abc = false;
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
        abc = true;
    }

    private void FixedUpdate()
    {
        if(waternum == 1 && waterbool)
        {
            transform.localScale += new Vector3(0.1f, 0, 0.1f);

            if (transform.localScale == new Vector3(1, transform.localScale.y, 1))
                waterbool = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Water" && !waterbool)
        {
            Debug.Log("Water");
            waternum++;
            waterbool = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(collision.gameObject.transform.name);
            rb.constraints = RigidbodyConstraints.FreezeAll;

            if(abc)
            {
                 Destroy(gameObject.GetComponent<Rigidbody>());
            }
        }  
    }
}
