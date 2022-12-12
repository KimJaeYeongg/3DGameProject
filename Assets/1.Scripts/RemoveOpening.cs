using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOpening : MonoBehaviour
{
    GameObject opening;
    private void Awake()
    {
        opening = GameObject.FindGameObjectWithTag("BGM");
        
        Destroy(opening);
    }
}
