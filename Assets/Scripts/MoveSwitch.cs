using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitch : MonoBehaviour
{
    public Transform currentSpot;
    public Transform pushSpot;
    public bool pushing;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pushing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pushing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pushSpot.position, Time.deltaTime * speed);
            Debug.Log("pushing");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentSpot.position, Time.deltaTime * speed);
            Debug.Log(currentSpot.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pushing = true;
            other.transform.SetParent(transform);
        }
    }

 

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pushing = false;
            other.transform.SetParent(null);
        }
    }

}
