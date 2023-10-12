using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfx;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            sfx.Pause();
            music.Play();
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            music.Pause();
            sfx.Play();
        }
    }
}
