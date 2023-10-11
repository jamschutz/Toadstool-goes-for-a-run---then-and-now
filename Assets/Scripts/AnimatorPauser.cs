using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPauser : MonoBehaviour
{
    private List<Animator> anims;


    private void Awake()
    {
        anims = new List<Animator>();
        foreach(var anim in GetComponentsInChildren<Animator>()) {
            anims.Add(anim);
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            foreach(var anim in anims) {
                anim.enabled = true;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            foreach(var anim in anims) {
                anim.enabled = false;
            }
        }
    }
}
