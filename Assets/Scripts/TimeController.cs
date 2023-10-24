using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public jsch.PlayerCharacterController youngToadController;
    public OldToadController oldToadController;
    public BlackOutFader blackOutFader;

    // singleton instance
    public static TimeController instance;

    public float leftTimer;
    public float rightTimer;
    private ActiveScene activeScene;


    private void Awake()
    {
        // ensure singleton instance 
        if(TimeController.instance != null && TimeController.instance != this) {
            Destroy(this.gameObject);
        }
        else {
            TimeController.instance = this;
        }
    }


    private void Start()
    {
        leftTimer = 0;
        rightTimer = 0;
        activeScene = ActiveScene.None;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            activeScene = ActiveScene.Left;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            activeScene = ActiveScene.Right;
        }

        float targetLeftTime = youngToadController.maxRunTime;
        float targetRightTime = oldToadController.maxRunTime;
        switch(activeScene) {
            case ActiveScene.None:
                break;
            case ActiveScene.Left:
                leftTimer -= Time.deltaTime;
                rightTimer += Time.deltaTime;
                targetLeftTime = blackOutFader.fadeInTime;
                break;
            case ActiveScene.Right:
                leftTimer += Time.deltaTime;
                rightTimer -= Time.deltaTime;
                targetRightTime = blackOutFader.fadeInTime;
                break;
        }
        leftTimer = Mathf.Clamp(leftTimer, 0.0f, targetLeftTime);
        rightTimer = Mathf.Clamp(rightTimer, 0.0f, targetRightTime);
    }


    public float GetTargetLeftTime()
    {
        return activeScene == ActiveScene.Left? blackOutFader.fadeInTime : youngToadController.maxRunTime;
    }
    public float GetTargetRightTime()
    {
        return activeScene == ActiveScene.Right? blackOutFader.fadeInTime : oldToadController.maxRunTime;
    }

    public bool TimeIsUp()
    {
        switch(activeScene) {
            case ActiveScene.None:
                return false;
            case ActiveScene.Left:
                return Mathf.Abs(rightTimer - oldToadController.maxRunTime) < float.Epsilon;
            case ActiveScene.Right:                
                return Mathf.Abs(leftTimer - youngToadController.maxRunTime) < float.Epsilon;
            default:
                return false;
        }
    }


    private enum ActiveScene { None, Left, Right }
}
