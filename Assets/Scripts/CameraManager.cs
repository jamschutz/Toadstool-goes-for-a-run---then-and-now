using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera youngCamera;
    public Camera oldCamera;
    public Transform youngToad;
    public Transform oldToad;


    // singleton instance
    public static CameraManager instance;

    private void Awake()
    {
        // ensure singleton instance 
        if(CameraManager.instance != null && CameraManager.instance != this) {
            Destroy(this.gameObject);
        }
        else {
            CameraManager.instance = this;
        }
    }


    public Camera GetYoungCamera()
    {
        return youngCamera;
    }


    public Camera GetOldCamera()
    {
        return oldCamera;
    }


    public Transform GetYoungToad()
    {
        return youngToad;
    }


    public Transform GetOldToad()
    {
        return oldToad;
    }
}
