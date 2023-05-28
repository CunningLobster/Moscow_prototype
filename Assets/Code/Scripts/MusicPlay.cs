using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<SoundManager>().PlaySceneMusic();
    }
}
