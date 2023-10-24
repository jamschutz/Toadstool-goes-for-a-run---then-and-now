using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOutFader : MonoBehaviour
{
    public jsch.PlayerCharacterController youngToadController;
    public OldToadController oldToadController;
    
    public Image leftBlackout;
    public Image rightBlackout;

    public AnimationCurve animCurve;
    public float fadeInTime;


    public float leftTimer;
    public float rightTimer;
    private ActiveScene activeScene;
    

    private void Start()
    {
        leftTimer = 0;
        rightTimer = 0;
        activeScene = ActiveScene.None;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            activeScene = ActiveScene.Right;
            rightTimer = (rightTimer / oldToadController.maxRunTime) * fadeInTime;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            activeScene = ActiveScene.Left;
            leftTimer = (leftTimer / youngToadController.maxRunTime) * fadeInTime;
        }

        float targetLeftTime = youngToadController.maxRunTime;
        float targetRightTime = oldToadController.maxRunTime;
        switch(activeScene) {
            case ActiveScene.None:
                break;
            case ActiveScene.Left:
                leftTimer -= Time.deltaTime;
                rightTimer += Time.deltaTime;
                targetLeftTime = fadeInTime;
                break;
            case ActiveScene.Right:
                leftTimer += Time.deltaTime;
                rightTimer -= Time.deltaTime;
                targetRightTime = fadeInTime;
                break;
        }
        leftTimer = Mathf.Clamp(leftTimer, 0.0f, targetLeftTime);
        rightTimer = Mathf.Clamp(rightTimer, 0.0f, targetRightTime);

        float leftAlpha = Mathf.Lerp(0.0f, 1.0f, leftTimer / targetLeftTime);
        float rightAlpha = Mathf.Lerp(0.0f, 1.0f, rightTimer / targetRightTime);
        rightBlackout.color = new Color(0, 0, 0, animCurve.Evaluate(leftAlpha));
        leftBlackout.color = new Color(0, 0, 0, animCurve.Evaluate(rightAlpha));
    }



    private enum ActiveScene { None, Left, Right }
}
