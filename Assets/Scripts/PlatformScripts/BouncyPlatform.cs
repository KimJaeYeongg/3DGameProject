using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public int disappearTime;
    public int appearTime;
    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Dis", disappearTime);
        }
    }

    void Dis()
    {
        gameObject.SetActive(false);
        Invoke("App", appearTime);
    }

    void App()
    {
        gameObject.SetActive(true);

    }
}
