using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtYoungToad : MonoBehaviour
{
    private Transform youngToad;


    private void Start()
    {
        youngToad = CameraManager.instance.GetYoungToad();
        transform.LookAt(youngToad);
    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            transform.LookAt(youngToad);
        }
    }
}
