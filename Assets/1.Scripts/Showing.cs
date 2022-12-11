using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showing : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, rotSpeed, 0));
    }
}
