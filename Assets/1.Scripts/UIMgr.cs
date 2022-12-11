using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public GameObject photoBook;

    private void Start()
    {
        photoBook.SetActive(false);
    }

    private void Update()
    {
        CheckClose();
    }

    public void OpenPhotoBook()
    {
        photoBook.SetActive(true);
    }

    public void CheckClose()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            photoBook.SetActive(false);
        }
    }
}
