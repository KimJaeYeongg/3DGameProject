using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public int disappearTime;
    public int appearTime;
    public int startTime = 0;
    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
        Invoke("App", startTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Dis()
    {
        gameObject.SetActive(false);
        Invoke("App", appearTime);
    }

    void App()
    {
        gameObject.SetActive(true);
        Invoke("Dis", disappearTime);
    }
}
