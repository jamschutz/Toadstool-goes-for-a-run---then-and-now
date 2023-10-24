using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldToadController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float maxRunTime;

    private bool firstSpace;
    public float timer;

    private void Start()
    {
        firstSpace = false;
        timer = 0;
    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            firstSpace = true;
            timer = 0;
            return;
        }
        else {
            timer += Time.deltaTime;
        }

        if(timer > maxRunTime)
            return;

        if(!firstSpace)
            return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
