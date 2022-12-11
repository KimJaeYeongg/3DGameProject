using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPlatform : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public MoveSwitch moveSwitch;
    Transform desPos;

    private bool abc;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
        abc = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
        if(moveSwitch.pushing)
        {
            if (abc)
            {
                desPos = endPos;
                abc = false;
            }
            if (Vector3.Distance(transform.position, desPos.position) <= 0.05f)
            {
                if (desPos == endPos)
                {
                    desPos = startPos;
                }
                else
                {
                    desPos = endPos;
                }
            }
        }
        else
        {
            abc = true;
            desPos = startPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
