using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartMap : MonoBehaviour
{
    //Fade ==================================================

    public float animTime = 2f;         // Fade 애니메이션 재생 시간 (단위:초).  
    public Image fadeImage;  

    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    public bool stopIn = true; //false일때 실행되는건데, 초기값을 false로 한 이유는 게임 시작할때 페이드인으로 들어가려고...그게 싫으면 true로 하면됨.
    public bool stopOut = true;

    //=======================================================

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayFadeIn());
    }

    IEnumerator PlayFadeIn()
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
            color.a = Mathf.Lerp(start, end, time);
            fadeImage.color = color;

            yield return null;
        }
    }
}
