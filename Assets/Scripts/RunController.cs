using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour
{
    public Animator[] animationControllers;

    private void Start()
    {
        foreach(var anim in animationControllers) {
            anim.enabled = false;
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            foreach(var anim in animationControllers) {
                anim.enabled = true;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            foreach(var anim in animationControllers) {
                anim.enabled = false;
            }
        }
    }
}
