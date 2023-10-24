using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfx;
    public float maxRunTime;

    private float timer;

    private void Start()
    {
        timer = 0;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)) {
            sfx.Pause();
            music.Play();
            timer = 0;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            music.Pause();
            sfx.Play();
            timer = 0;
        }

        if(timer > maxRunTime) {
            if(sfx.isPlaying) sfx.Pause();
            if(music.isPlaying) music.Pause();
        }
    }
}
