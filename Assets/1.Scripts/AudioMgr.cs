using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SFX
{
    public AudioClip shutterSound;
    public AudioClip popSound;
}

public class AudioMgr : MonoBehaviour
{
    public SFX sfx;
}
