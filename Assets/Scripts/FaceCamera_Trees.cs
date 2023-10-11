using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FaceCamera_Trees : MonoBehaviour
{
    private Transform targetCam;

    private void Start()
    {
        if(transform.parent.name == "trees - OLD") {
            targetCam = CameraManager.instance.GetOldCamera().transform;
        }
        else if(transform.parent.name == "trees - YOUNG") {
            targetCam = CameraManager.instance.GetYoungCamera().transform;
        }
    }


    private void Update()
    {
        transform.LookAt(targetCam, Vector3.up);
    }
}
