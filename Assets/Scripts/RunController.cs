using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour
{
    public Animator youngToad;
    public Animator oldToad;

    private void Start()
    {
        oldToad.enabled = false;
        youngToad.enabled = false;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            oldToad.enabled = false;
            youngToad.enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            oldToad.enabled = true;
            youngToad.enabled = false;
        }
    }
}
