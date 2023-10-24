using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour
{
    public Animator youngToad;
    public Animator oldToad;
    public float maxRunTime;

    private float timer;

    private void Start()
    {
        oldToad.enabled = false;
        youngToad.enabled = false;
        timer = 0;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            oldToad.enabled = false;
            youngToad.enabled = true;
            timer = 0;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            oldToad.enabled = true;
            youngToad.enabled = false;
            timer = 0;
        }

        if(timer > maxRunTime) {
            oldToad.enabled = false;
            youngToad.enabled = false;
        }
    }
}
