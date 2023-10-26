using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Controls")]
    public float rotateX;
    public float rotateY;
    public bool rotateAlways = true;

    [Header("Zoom")]
    public Vector3 maxDistance;
    public Vector3 minDistance;
    public float fadeInTime;
    public float fadeOutTime;


    Transform pivot;
    float angleX;
    float angleY;


    float timer;
    float dollyTimer;


    void Start()
    {
        pivot = transform.parent;
        angleX = pivot.eulerAngles.x;
        angleY = pivot.eulerAngles.y;
        timer = 0;
        dollyTimer = 0;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    void Update()
    {
        bool isSpaceDown = Input.GetKey(KeyCode.Space);
        // rotate camera
        if(isSpaceDown || rotateAlways) {
            if(Input.GetKey(KeyCode.LeftArrow)) {
                angleY -= rotateY * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.RightArrow)) {
                angleY += rotateY * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.UpArrow)) {
                angleX += rotateX * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.DownArrow)) {
                angleX -= rotateX * Time.deltaTime;
            }
            angleX = Mathf.Clamp(angleX, -15, 30);
            
            pivot.eulerAngles = new Vector3(angleX, angleY, 0);
        }
        

        // move camera
        float fadeTime;
        if(Input.GetKey(KeyCode.Space)) {
            dollyTimer += Time.deltaTime;
            fadeTime = fadeInTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, minDistance, fadeInTime * Time.deltaTime);
        }
        else {
            if(dollyTimer > fadeOutTime)
                dollyTimer = (dollyTimer / fadeInTime) * fadeOutTime;

            fadeTime = fadeOutTime;
            dollyTimer -= Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, maxDistance, fadeOutTime * Time.deltaTime);
        }
        // dollyTimer = Mathf.Clamp(dollyTimer, 0, fadeTime);
        // transform.localPosition = Vector3.Lerp(maxDistance, minDistance, dollyTimer / fadeTime);
    }
}
