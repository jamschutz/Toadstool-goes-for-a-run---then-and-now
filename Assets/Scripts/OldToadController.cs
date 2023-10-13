using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldToadController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;

    private bool firstSpace;

    private void Start()
    {
        firstSpace = false;
    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            firstSpace = true;
            return;
        }

        if(!firstSpace)
            return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
