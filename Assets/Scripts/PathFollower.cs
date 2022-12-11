using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{

    public float speed = 3f;
    public Transform pathParent;
    Transform targetPoint;
    int index;
    Animator m_animator;

    private bool Startbool;
   // public Transform target;

    void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;
        for (int a = 0; a < pathParent.childCount - 1; a++)
        {
            from = pathParent.GetChild(a).position;
            to = pathParent.GetChild((a + 1) % pathParent.childCount).position;
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawLine(from, to);


        }
    }
    void Start()
    {
        index = 0;
        targetPoint = pathParent.GetChild(index);
        m_animator = GetComponent<Animator>();
        Startbool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Startbool)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                index++;
                index %= pathParent.childCount;
                targetPoint = pathParent.GetChild(index);
                if (index == 0)
                    Debug.Log("다음 스테이지");
            }
            m_animator.SetFloat("MoveSpeed", 1.1f);
            //this.transform.LookAt(target);
        }


    }

    public void StartButton()
    {
        Startbool = true;
    }

}