using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinToads : MonoBehaviour
{
    public float spinSpeed;

    Vector3 angle;


    private void Start()
    {
        angle = transform.eulerAngles;
    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            angle.y += spinSpeed * Time.deltaTime;
            transform.eulerAngles = angle;
        }
    }
}
