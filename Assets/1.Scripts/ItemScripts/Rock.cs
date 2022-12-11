using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Item
{
    protected override void CreateInstance(Vector3 hitPos)
    {
        GameObject item = Instantiate(ItemObject);
        item.transform.position = hitPos;
        item.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bee")
        {
            BeeMove beeDie = collision.gameObject.GetComponent<BeeMove>();
            beeDie.MonsterDie();
        }
    }
}
