using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PathFollower : MonoBehaviour
{

    public float speed = 3f;
    public Transform pathParent;
    Transform targetPoint;
    private int index;
    Animator m_animator;

    private bool Startbool;
    private bool nextScene;
    // public Transform target;

    //Fade ==================================================

    public float animTime = 2f;         // Fade 애니메이션 재생 시간 (단위:초).  
    public Image fadeImage;

    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    public bool stopIn = true; //false일때 실행되는건데, 초기값을 false로 한 이유는 게임 시작할때 페이드인으로 들어가려고...그게 싫으면 true로 하면됨.
    public bool stopOut = true;

    //=======================================================

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
        nextScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Startbool && !nextScene)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                index++;
                index %= pathParent.childCount;
                targetPoint = pathParent.GetChild(index);
                if (index == 0)
                {
                    StartCoroutine(PlayFadeOut());
                    Invoke("LoadScene", 3f);
                    m_animator.SetFloat("MoveSpeed", 0);
                    nextScene = true;
                    return;
                }
            }
            m_animator.SetFloat("MoveSpeed", 1.1f);
            //this.transform.LookAt(target);
        }


    }

    public void StartButton()
    {
        Startbool = true;
    }

    IEnumerator PlayFadeOut()
    {
        while (true)
        {
            if (time >= animTime)
            {
                time = 0;
                yield break;
            }

            time += Time.deltaTime / animTime;
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(end, start, time);
            fadeImage.color = color;

            yield return null;
        }
    }

    public void LoadScene() 
    {
        SceneManager.LoadScene("GameMap");
    }
}