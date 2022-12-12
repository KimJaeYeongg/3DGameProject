using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingEvent : MonoBehaviour
{

    public GameObject ending;
    // Start is called before the first frame update
    void Start()
    {
        ending.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ending.SetActive(true);
        }
    }
}
