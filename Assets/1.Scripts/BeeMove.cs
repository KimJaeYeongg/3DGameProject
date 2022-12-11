using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            MonsterDie(); 
        }
    }

    void MonsterDie()
    {
        StopAllCoroutines();

        anim.SetTrigger("isDie");

        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Invoke("Gone", 2f);
    }

    void Gone()
    {
        Destroy(gameObject);
    }
}
