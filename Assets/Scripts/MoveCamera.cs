using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Controls")]
    public float rotateX;
    public float rotateY;

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
        // rotate camera
        angleX -= Input.GetAxis("Mouse Y") * rotateX * Time.deltaTime;
        angleY += Input.GetAxis("Mouse X") * rotateY * Time.deltaTime;
        pivot.eulerAngles = new Vector3(angleX, angleY, 0);

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
