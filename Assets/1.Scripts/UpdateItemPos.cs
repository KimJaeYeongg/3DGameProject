using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pos
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
}

public class UpdateItemPos : MonoBehaviour
{
    public Pos pos;

    public Transform startPos;

    private void Start()
    {
        transform.position = startPos.position;
    }
    public void notify(int pos)
    {
        switch (pos)
        {
            case 1:
                transform.position = this.pos.pos1.position;
                break;
            case 2:
                transform.position = this.pos.pos2.position;
                break;
            case 3:
                transform.position = this.pos.pos3.position;
                break;
            case 4:
                transform.position = this.pos.pos4.position;
                break;
            case 5:
                transform.position = this.pos.pos5.position;
                break;
        }
    }
}
