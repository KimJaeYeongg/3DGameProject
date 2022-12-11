using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [Range(0, 1000)]
    public float bouncehight;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Jump");
            GameObject bouncer = collision.gameObject;
            Rigidbody rb = bouncer.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * bouncehight);
        }
    }
}
